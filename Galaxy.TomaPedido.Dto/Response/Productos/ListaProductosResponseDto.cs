namespace Galaxy.TomaPedido.Dto.Response.Productos
{
    public class ListaProductosResponseDto
    {
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;

		public string Descripcion { get; set; } = null!;		

		public string Marca { get; set; } = default!;

		public string Categoria { get; set; } = default!;

		public decimal? PrecioUnitario { get; set; }

		public int? Stock { get; set; }
		public int? Cantidad { get; set; }
	}
}
