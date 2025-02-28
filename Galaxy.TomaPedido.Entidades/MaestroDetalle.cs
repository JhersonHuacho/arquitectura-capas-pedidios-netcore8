using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class MaestroDetalle
{
	public int Id { get; set; }

	public int IdMaestro { get; set; }

	public string? Codigo { get; set; }

	public string? Valor { get; set; }

	public bool Estado { get; set; }

	public DateTime FechaCreacion { get; set; }

	public string UsuarioCreacion { get; set; } = null!;

	public DateTime? FechaModificacion { get; set; }

	public string? UsuarioModificacion { get; set; }

	public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

	public virtual Maestro IdMaestroNavigation { get; set; } = null!;

	public virtual ICollection<PedidoTracking> PedidoTrackings { get; set; } = new List<PedidoTracking>();

	public virtual ICollection<Producto> ProductoIdCategoriaMaeNavigations { get; set; } = new List<Producto>();

	public virtual ICollection<Producto> ProductoIdMarcaMaeNavigations { get; set; } = new List<Producto>();
}
