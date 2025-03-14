using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class PedidoTracking : EntidadBase
{
	public int IdPedido { get; set; }

	public int IdEstadoMae { get; set; }

	public string? Comentario { get; set; }

	public virtual MaestroDetalle IdEstadoMaeNavigation { get; set; } = null!;

	public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
