using AutoMapper;
using Galaxy.TomaPedido.Dto.Response.Maestros;
using Galaxy.TomaPedido.Entidades;

namespace Galaxy.TomaPedido.Servicio.Mappers
{
    public class MaestroMap : Profile
    {
		public MaestroMap()
		{
			CreateMap<MaestroDetalle, DetalleMaestroResponse>();
		}
	}
}
