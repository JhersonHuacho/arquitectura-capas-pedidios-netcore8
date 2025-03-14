namespace Galaxy.TomaPedido.Dto.Request.Clientes
{
	public class ClienteRequestDto
	{
		public string RazonSocial { get; set; } = null!;

		public string NumeroDocumento { get; set; } = null!;

		public string? Contacto { get; set; }

		public string? Direccion { get; set; }

		public string? CorreoElectronico { get; set; }

		public string? Celular { get; set; }

		public int IdRubroMae { get; set; }
	}
}
