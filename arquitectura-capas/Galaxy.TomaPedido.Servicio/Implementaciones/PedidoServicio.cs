using AutoMapper;
using Galaxy.TomaPedido.Comun;
using Galaxy.TomaPedido.Dto.Request.Pedidos;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Galaxy.TomaPedido.Servicio.Interfaces;

namespace Galaxy.TomaPedido.Servicio.Implementaciones
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
		private readonly IProductoRepositorio _productoRepositorio;
		private readonly IMapper _mapper;

		public PedidoServicio(IPedidoRepositorio pedidoRepositorio, IProductoRepositorio productoRepositorio, IMapper mapper)
		{
			_pedidoRepositorio = pedidoRepositorio;
			_productoRepositorio = productoRepositorio;
			_mapper = mapper;
		}

		public async Task<BaseResponse> Registrar(PedidoRequest request)
		{
			var respuesta = new BaseResponse();
			try
			{
				var productos = await _productoRepositorio.ListarPorId(request.PedidoDetalles.Select(p => p.IdProducto).ToList());

				if (productos != null)
				{
					if (request.PedidoDetalles.Count != productos.Count)
					{
						respuesta.Message = "No se encontraron todos los productos";
						return respuesta;
					}

					var productosSinStock = productos
						.Where(p => p.Stock - request.PedidoDetalles.First(pd => pd.IdProducto == p.Id).Cantidad < 0)
						.ToList();

					if (productosSinStock != null && productosSinStock.Count > 0)
					{
						respuesta.Message = $"Los productos {string.Join(", ", productosSinStock.Select(p => p.Nombre))} no tienen stock suficiente";
						return respuesta;
					}

					var pedido = _mapper.Map<Pedido>(request);
					pedido.TotalBruto = request.PedidoDetalles.Sum(pd => pd.Cantidad * pd.PrecioUnitario);
					//pedido.TotalNeto = pedido.TotalBruto - (pedido.TotalBruto * 0.18m);
					pedido.TotalNeto = Helpers.CalcularTotalNeto(pedido.TotalBruto);

					var detalle = pedido.PedidoDetalles.ToList();
					detalle.ForEach(p =>
					{
						p.TotalBruto = p.Cantidad * p.PrecioUnitario;
						p.TotalNeto = Helpers.CalcularTotalNeto(p.TotalBruto);
					});

					await _pedidoRepositorio.Registrar(pedido, detalle);

					respuesta.Success = true;
					respuesta.Message = "Pedido registrado correctamente";
				}
			}
			catch (Exception)
			{
				respuesta.Success = false;
				respuesta.Message = "Ocurrió un error al registrar el pedido";
			}

			return respuesta;
		}
	}
}
