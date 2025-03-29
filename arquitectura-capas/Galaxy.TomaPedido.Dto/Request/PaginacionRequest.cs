namespace Galaxy.TomaPedido.Dto.Request
{
    public class PaginacionRequest
    {
		public int Pagina { get; set; } = 1;
		public int Filas { get; set; } = 10;
	}
}
