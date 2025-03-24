using Galaxy.TomaPedido.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.TomaPedido.Repositorios.Interfaces
{
    public interface IProductoRepositorio : IRepositorioBase<Producto>
	{
		Task<List<Producto>> ListarPorId(List<int> listaId);

	}
}
