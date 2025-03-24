using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.TomaPedido.Repositorios.Implementaciones
{
    public class PedidoRepositorio : RepositorioBase<Pedido>, IPedidoRepositorio
	{
		private readonly BdpedidosContext _bdpedidosContext;
		public PedidoRepositorio(BdpedidosContext bdpedidosContext) : base(bdpedidosContext)
		{
			_bdpedidosContext = bdpedidosContext;
		}

		public async Task Registrar(Pedido pedido, List<PedidoDetalle> pedidoDetalles)
		{
			await using (var transaction = await _bdPedidoContext.Database.BeginTransactionAsync())
			{
				try
				{
					// Registrar el pedido
					var nuevo = await _bdPedidoContext.Pedidos.AddAsync(pedido);
					await _bdPedidoContext.SaveChangesAsync();

					//// Asignación del IdPedido a cada detalle
					//pedidoDetalles.ForEach(x => x.IdPedido = nuevo.Entity.Id);

					//// Registrar los detalles
					//await _bdPedidoContext.PedidoDetalles.AddRangeAsync(pedidoDetalles);
					//await _bdPedidoContext.SaveChangesAsync();

					// Descontar el stock
					foreach (var detalle in pedidoDetalles)
					{
						//await _bdPedidoContext.Productos
						//	.Where(x => x.Id == detalle.IdProducto)
						//	.ExecuteUpdateAsync(p => 
						//		p.SetProperty(p => p.Stock, -detalle.Cantidad));

						var producto = await _bdPedidoContext.Productos.FindAsync(detalle.IdProducto);
						producto.Stock -= detalle.Cantidad;

						_bdPedidoContext.Productos.Update(producto);
					}

					// Registrar el tracking
					var estado = await _bdPedidoContext.MaestroDetalles.FirstOrDefaultAsync(x => x.Codigo == "PDD_REGISTRADO");

					if (estado == null) throw new InvalidDataException("No se encontró el estado REGISTRADO");

					PedidoTracking pedidoTracking = new PedidoTracking
					{
						IdPedido = nuevo.Entity.Id,
						IdEstadoMae = estado.Id,
						Comentario = "Pedido registrado correctamente",
					};

					await _bdPedidoContext.PedidoTrackings.AddAsync(pedidoTracking);
					await _bdPedidoContext.SaveChangesAsync();

					await transaction.CommitAsync();
				}
				catch (Exception)
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
		}
	}
}
