namespace Galaxy.TomaPedido.Dto.Response.Productos
{
    public class ProductoResponseDto
    {
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;

		public string Descripcion { get; set; } = null!;

		public int IdMarcaMae { get; set; }

		public int IdCategoriaMae { get; set; }

		public decimal? PrecioUnitario { get; set; }

		public int? Stock { get; set; }
	}
}
