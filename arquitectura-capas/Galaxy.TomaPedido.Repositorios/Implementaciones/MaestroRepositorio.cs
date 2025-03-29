using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;

namespace Galaxy.TomaPedido.Repositorios.Implementaciones
{
	public class MaestroRepositorio : RepositorioBase<Maestro>, IMaestroRepositorio
	{
		private readonly BdpedidosContext _bdPedidoContext;
		public MaestroRepositorio(BdpedidosContext bdPedidoContext) : base(bdPedidoContext)
		{
			_bdPedidoContext = bdPedidoContext;
		}
	}
}
