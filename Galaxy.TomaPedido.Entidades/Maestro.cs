using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class Maestro
{
	public int Id { get; set; }

	public string Codigo { get; set; } = null!;

	public string Nombre { get; set; } = null!;

	public string? Descripcion { get; set; }

	public bool Estado { get; set; }

	public DateTime FechaCreacion { get; set; }

	public string UsuarioCreacion { get; set; } = null!;

	public DateTime? FechaModificacion { get; set; }

	public string? UsuarioModificacion { get; set; }

	public virtual ICollection<MaestroDetalle> MaestroDetalles { get; set; } = new List<MaestroDetalle>();
}
