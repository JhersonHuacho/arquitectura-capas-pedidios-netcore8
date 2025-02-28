using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class PedidoTracking
{
	public int Id { get; set; }

	public int IdPedido { get; set; }

	public int IdEstadoMae { get; set; }

	public string? Comentario { get; set; }

	public bool Estado { get; set; }

	public DateTime FechaCreacion { get; set; }

	public string UsuarioCreacion { get; set; } = null!;

	public DateTime? FechaModificacion { get; set; }

	public string? UsuarioModificacion { get; set; }

	public virtual MaestroDetalle IdEstadoMaeNavigation { get; set; } = null!;

	public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
