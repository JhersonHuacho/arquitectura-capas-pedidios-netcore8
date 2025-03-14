using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;

namespace Galaxy.TomaPedido.Repositorios.Implementaciones
{
	public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
	{
		private readonly BdpedidosContext _bdPedidoContext;
		public ClienteRepositorio(BdpedidosContext bdPedidoContext) : base(bdPedidoContext)
		{
			_bdPedidoContext = bdPedidoContext;
		}
	}
}
