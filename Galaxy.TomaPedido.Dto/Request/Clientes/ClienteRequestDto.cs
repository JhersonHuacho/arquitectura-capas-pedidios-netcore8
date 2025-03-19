using Galaxy.TomaPedido.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.TomaPedido.Dto.Request.Clientes
{
	public class ClienteRequestDto
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Razon Social")]
		public string RazonSocial { get; set; } = null!;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Número de Documento")]
		public string NumeroDocumento { get; set; } = default!;

		public string? Contacto { get; set; }

		public string? Direccion { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Correo Electronico")]
		public string CorreoElectronico { get; set; } = default!;

		public string? Celular { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues("0", ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Rubro")]
		public int IdRubroMae { get; set; }
	}
}
