using Galaxy.TomaPedido.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.TomaPedido.Dto.Request.Productos
{
    public class ProductoRequestDto
    {
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		public string Nombre { get; set; } = null!;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		public string Descripcion { get; set; } = null!;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		public int IdMarcaMae { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		public int IdCategoriaMae { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		public decimal? PrecioUnitario { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		public int? Stock { get; set; }
	}
}
