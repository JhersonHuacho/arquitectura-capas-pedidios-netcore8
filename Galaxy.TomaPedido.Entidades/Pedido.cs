﻿using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class Pedido
{
	public int Id { get; set; }

	public int IdCliente { get; set; }

	public int IdColaborador { get; set; }

	public decimal? TotalBruto { get; set; }

	public decimal? TotalNeto { get; set; }

	public decimal? Adelanto { get; set; }

	public bool Estado { get; set; }

	public DateTime FechaCreacion { get; set; }

	public string UsuarioCreacion { get; set; } = null!;

	public DateTime? FechaModificacion { get; set; }

	public string? UsuarioModificacion { get; set; }

	public virtual Cliente IdClienteNavigation { get; set; } = null!;

	public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();

	public virtual ICollection<PedidoTracking> PedidoTrackings { get; set; } = new List<PedidoTracking>();
}
