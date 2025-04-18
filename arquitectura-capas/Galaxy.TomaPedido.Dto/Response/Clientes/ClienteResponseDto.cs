﻿namespace Galaxy.TomaPedido.Dto.Response.Clientes
{
    public class ClienteResponseDto
    {
		public int Id { get; set; }
		public string RazonSocial { get; set; } = null!;

		public string NumeroDocumento { get; set; } = null!;

		public string? Contacto { get; set; }

		public string? Direccion { get; set; }

		public string CorreoElectronico { get; set; } = default!;

		public string? Celular { get; set; }

		public int IdRubroMae { get; set; }
	}
}
