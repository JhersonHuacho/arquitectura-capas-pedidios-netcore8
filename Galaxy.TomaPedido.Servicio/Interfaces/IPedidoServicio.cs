using Galaxy.TomaPedido.Dto.Request.Pedidos;
using Galaxy.TomaPedido.Dto.Response;

namespace Galaxy.TomaPedido.Servicio.Interfaces
{
    public interface IPedidoServicio
    {
		Task<BaseResponse> Registrar(PedidoRequest request);
	}
}
