using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.TomaPedido.Dto.Request.Clientes
{
    public class BusquedaClientesRequest : PaginacionRequest
    {
		public string RazonSocial { get; set; } = default!;
		public string Ruc { get; set; } = default!;
	}
}
