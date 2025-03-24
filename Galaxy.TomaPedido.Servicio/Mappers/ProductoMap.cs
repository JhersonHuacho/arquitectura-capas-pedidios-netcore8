using AutoMapper;
using Galaxy.TomaPedido.Dto.Request.Productos;
using Galaxy.TomaPedido.Dto.Response.Productos;
using Galaxy.TomaPedido.Entidades;

namespace Galaxy.TomaPedido.Servicio.Mappers
{
    public class ProductoMap : Profile
    {
		public ProductoMap()
		{
			CreateMap<ProductoRequestDto, Producto>();
			CreateMap<Producto, ListaProductosResponseDto>();
			CreateMap<Producto, ProductoResponseDto>();
		}
	}
}
