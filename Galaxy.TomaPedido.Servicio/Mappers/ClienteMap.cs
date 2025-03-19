using AutoMapper;
using Galaxy.TomaPedido.Dto.Request.Clientes;
using Galaxy.TomaPedido.Dto.Response.Clientes;
using Galaxy.TomaPedido.Entidades;

namespace Galaxy.TomaPedido.Servicio.Mappers
{
    public class ClienteMap : Profile
    {
		public ClienteMap()
		{
			CreateMap<ClienteRequestDto, Cliente>();
			CreateMap<Cliente, ListaClientesResponseDto>()
				.ForMember(p => p.Rubro, origen => origen.MapFrom(o => o.IdRubroMaeNavigation.Valor));
		}
	}
}
