namespace Galaxy.TomaPedido.Dto.Request.Pedidos
{
    public class PedidoRequest
    {
		public int IdCliente { get; set; }

		public decimal? Adelanto { get; set; }

		public ICollection<PedidoDetalleRequest> PedidoDetalles { get; set; } = new List<PedidoDetalleRequest>();
	}

	public class PedidoDetalleRequest
	{
		public int IdProducto { get; set; }
		public int Cantidad { get; set; }
		public decimal PrecioUnitario { get; set; }
	}
}
