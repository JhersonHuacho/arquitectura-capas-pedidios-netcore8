using Galaxy.TomaPedido.Dto.Request.Clientes;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Clientes;

namespace Galaxy.TomaPedido.Servicio.Interfaces
{
	public interface IClienteServicio
	{
		Task<BaseResponse> Registrar(ClienteRequestDto clienteRequestDto);
		Task<BaseResponse> Actualizar(int id, ClienteRequestDto requestDto);
		Task<BaseResponse<ClienteResponseDto>> ObtenerPorId(int id);
		Task<BaseResponse> Eliminar(int id);
		Task<PaginacionResponse<ListaClientesResponseDto>> Listar(BusquedaClientesRequest request);
	}
}
