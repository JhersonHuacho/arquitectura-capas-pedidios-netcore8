using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class Producto : EntidadBase
{	
	public string Nombre { get; set; } = null!;

	public string Descripcion { get; set; } = null!;

	public int IdMarcaMae { get; set; }

	public int IdCategoriaMae { get; set; }

	public decimal? PrecioUnitario { get; set; }

	public int? Stock { get; set; }

	public virtual MaestroDetalle IdCategoriaMaeNavigation { get; set; } = null!;

	public virtual MaestroDetalle IdMarcaMaeNavigation { get; set; } = null!;

	public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
