using Galaxy.TomaPedido.Dto.Request.Clientes;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Clientes;

namespace Galaxy.TomaPedido.Servicio.Interfaces
{
	public interface IClienteServicio
	{
		Task<BaseResponse> Registrar(ClienteRequestDto clienteRequestDto);
		Task<PaginacionResponse<ListaClientesResponseDto>> Listar(BusquedaClientesRequest request);
	}
}
