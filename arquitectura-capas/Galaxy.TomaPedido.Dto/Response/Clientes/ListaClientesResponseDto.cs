namespace Galaxy.TomaPedido.Dto.Response.Clientes
{
    public class ListaClientesResponseDto
    {
		public int Id { get; set; }
		public string RazonSocial { get; set; } = null!;

		public string NumeroDocumento { get; set; } = null!;

		public string? Contacto { get; set; }

		public string? Direccion { get; set; }

		public string? CorreoElectronico { get; set; }

		public string? Celular { get; set; }

		public string Rubro { get; set; } = default!;
	}
}
