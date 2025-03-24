using AutoMapper;
using Galaxy.TomaPedido.Comun;
using Galaxy.TomaPedido.Dto.Request.Productos;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Productos;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Galaxy.TomaPedido.Servicio.Interfaces;

namespace Galaxy.TomaPedido.Servicio.Implementaciones
{
    public class ProductoServicio : IProductoServicio
	{
		private readonly IProductoRepositorio _productoRepositorio;
		private readonly IMapper _mapper;

		public ProductoServicio(IProductoRepositorio productoRepositorio, IMapper mapper)
		{
			_productoRepositorio = productoRepositorio;
			_mapper = mapper;
		}

		public async Task<BaseResponse> Actualizar(int id, ProductoRequestDto requestDto)
		{
			var response = new BaseResponse();

			try
			{
				var producto = await _productoRepositorio.FindAsync(id);
				if (producto == null)
				{
					throw new InvalidCastException("Producto no encontrado");
				}

				_mapper.Map(requestDto, producto);

				await _productoRepositorio.UpdateAsync();

				response.Message = "Producto actualizado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<BaseResponse> Eliminar(int id)
		{
			var response = new BaseResponse();

			try
			{
				var producto = await _productoRepositorio.FindAsync(id);
				if (producto == null)
				{
					throw new InvalidCastException("Producto no encontrado");
				}

				await _productoRepositorio.DeleteAsync(id);

				response.Message = "Producto eliminado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<PaginacionResponse<ListaProductosResponseDto>> Listar(BusquedaProductosRequestDto request)
		{
			var response = new PaginacionResponse<ListaProductosResponseDto>();

			try
			{
				var resultado = await _productoRepositorio.ListAsync(
					predicado: p => p.Estado == true &&
						(string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
					selector: p => new ListaProductosResponseDto
					{						
						Id = p.Id,
						Nombre = p.Nombre,
						Descripcion = p.Descripcion,
						Marca = p.IdMarcaMaeNavigation.Valor!,
						Categoria = p.IdCategoriaMaeNavigation.Valor!,
						PrecioUnitario = p.PrecioUnitario,
						Stock = p.Stock
					},
					orderBy: p => p.Nombre,
					pagina: request.Pagina,
					filas: request.Filas);


				//selector: p => _mapper.Map<ListaProductosResponseDto>(p),

				response.Data = resultado.Collection;
				response.Success = true;
				response.TotalFilas = resultado.TotalRegistro;
				response.TotalPaginas = Helpers.CalcularNumeroPaginas(resultado.TotalRegistro, request.Filas);
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<BaseResponse<ProductoResponseDto>> ObtenerPorId(int id)
		{
			var response = new BaseResponse<ProductoResponseDto>();

			try
			{
				var producto = await _productoRepositorio.FindAsync(id);
				if (producto == null)
				{
					throw new InvalidCastException("Producto no encontrado");
				}

				response.Data = _mapper.Map<ProductoResponseDto>(producto);
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<BaseResponse> Registrar(ProductoRequestDto requestDto)
		{
			var response = new BaseResponse();

			try
			{
				var Producto = _mapper.Map<Producto>(requestDto);

				await _productoRepositorio.AddAsync(Producto);

				response.Message = "Producto registrado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}
