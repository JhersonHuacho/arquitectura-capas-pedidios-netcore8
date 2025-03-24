using Galaxy.TomaPedido.Entidades;

namespace Galaxy.TomaPedido.Repositorios.Interfaces
{
    public interface IPedidoRepositorio : IRepositorioBase<Pedido>
	{
		Task Registrar(Pedido pedido, List<PedidoDetalle> pedidoDetalles);
	}
}
