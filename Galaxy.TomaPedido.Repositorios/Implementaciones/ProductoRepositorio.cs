using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.TomaPedido.Repositorios.Implementaciones
{
    public class ProductoRepositorio : RepositorioBase<Producto>, IProductoRepositorio
	{
        private readonly BdpedidosContext _bdPedidoContext;

		public ProductoRepositorio(BdpedidosContext bdPedidoContext): base(bdPedidoContext)
		{
			_bdPedidoContext = bdPedidoContext;
		}

		public async Task<List<Producto>> ListarPorId(List<int> listaId)
		{
			var resultado = await _bdPedidoContext.Productos
				.Where(p => listaId.Contains(p.Id))
				.ToListAsync();

			return resultado;
		}
	}
}
