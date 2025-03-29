namespace Galaxy.TomaPedido.Dto.Request.Productos
{
    public class BusquedaProductosRequestDto : PaginacionRequest
	{
		public string? Nombre { get; set; }
	}
}
