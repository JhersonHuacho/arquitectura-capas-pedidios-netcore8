using AutoMapper;
using Galaxy.TomaPedido.Dto.Request.Pedidos;
using Galaxy.TomaPedido.Entidades;

namespace Galaxy.TomaPedido.Servicio.Mappers
{
    public class PedidoMap : Profile
    {
		public PedidoMap()
		{
			CreateMap<PedidoDetalleRequest, PedidoDetalle>();
			CreateMap<PedidoRequest, Pedido>();
		}
	}
}
