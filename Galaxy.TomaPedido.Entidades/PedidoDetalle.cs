using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class PedidoDetalle
{
	public int Id { get; set; }

	public int IdPedido { get; set; }

	public int IdProducto { get; set; }

	public int Cantidad { get; set; }

	public decimal PrecioUnitario { get; set; }

	public decimal TotalBruto { get; set; }

	public decimal? TotalNeto { get; set; }

	public bool Estado { get; set; }

	public DateTime FechaCreacion { get; set; }

	public string UsuarioCreacion { get; set; } = null!;

	public DateTime? FechaModificacion { get; set; }

	public string? UsuarioModificacion { get; set; }

	public virtual Pedido IdPedidoNavigation { get; set; } = null!;

	public virtual Producto IdProductoNavigation { get; set; } = null!;
}
