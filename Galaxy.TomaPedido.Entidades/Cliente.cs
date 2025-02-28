using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class Cliente
{
	public int Id { get; set; }

	public string RazonSocial { get; set; } = null!;

	public string NumeroDocumento { get; set; } = null!;

	public string? Contacto { get; set; }

	public string? Direccion { get; set; }

	public string? CorreoElectronico { get; set; }

	public string? Celular { get; set; }

	public int IdRubroMae { get; set; }

	public bool Estado { get; set; }

	public DateTime FechaCreacion { get; set; }

	public string UsuarioCreacion { get; set; } = null!;

	public DateTime? FechaModificacion { get; set; }

	public string? UsuarioModificacion { get; set; }

	public virtual MaestroDetalle IdRubroMaeNavigation { get; set; } = null!;

	public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
