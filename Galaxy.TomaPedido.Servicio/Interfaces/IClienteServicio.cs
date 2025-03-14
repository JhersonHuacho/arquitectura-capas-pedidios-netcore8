using Galaxy.TomaPedido.Dto.Request.Clientes;
using Galaxy.TomaPedido.Dto.Response;

namespace Galaxy.TomaPedido.Servicio.Interfaces
{
	public interface IClienteServicio
	{
		Task<BaseResponse> Registrar(ClienteRequestDto clienteRequestDto);
	}
}
