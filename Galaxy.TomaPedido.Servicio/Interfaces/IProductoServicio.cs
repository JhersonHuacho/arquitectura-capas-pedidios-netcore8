using Galaxy.TomaPedido.Dto.Request.Productos;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Clientes;
using Galaxy.TomaPedido.Dto.Response.Productos;

namespace Galaxy.TomaPedido.Servicio.Interfaces
{
    public interface IProductoServicio
    {
		Task<BaseResponse> Registrar(ProductoRequestDto requestDto);
		Task<BaseResponse> Actualizar(int id, ProductoRequestDto requestDto);
		Task<BaseResponse<ProductoResponseDto>> ObtenerPorId(int id);
		Task<BaseResponse> Eliminar(int id);
		Task<PaginacionResponse<ListaProductosResponseDto>> Listar(BusquedaProductosRequestDto requestDto);
	}
}
