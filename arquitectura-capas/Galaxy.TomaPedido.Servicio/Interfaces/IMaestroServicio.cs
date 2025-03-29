using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Maestros;

namespace Galaxy.TomaPedido.Servicio.Interfaces
{
    public interface IMaestroServicio
    {
		Task<BaseResponse<List<DetalleMaestroResponse>>> ListarDetalleByCodigoPadre(string codigoPadre);
	}
}
