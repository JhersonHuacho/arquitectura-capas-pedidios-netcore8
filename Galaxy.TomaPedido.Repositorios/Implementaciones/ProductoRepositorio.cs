using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;

namespace Galaxy.TomaPedido.Repositorios.Implementaciones
{
    public class ProductoRepositorio : RepositorioBase<Producto>, IProductoRepositorio
	{
        private readonly BdpedidosContext _bdPedidoContext;

		public ProductoRepositorio(BdpedidosContext bdPedidoContext): base(bdPedidoContext)
		{
			_bdPedidoContext = bdPedidoContext;
		}
	}
}
