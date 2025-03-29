using AutoMapper;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Maestros;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Galaxy.TomaPedido.Servicio.Interfaces;

namespace Galaxy.TomaPedido.Servicio.Implementaciones
{
    public class MestroServicio : IMaestroServicio
    {
        private readonly IMaestroRepositorio _maestroRepositorio;
		private readonly IMapper _mapper;

		public MestroServicio(IMaestroRepositorio maestroRepositorio, IMapper mapper)
		{
			_maestroRepositorio = maestroRepositorio;
			_mapper = mapper;
		}

		public async Task<BaseResponse<List<DetalleMaestroResponse>>> ListarDetalleByCodigoPadre(string codigoPadre)
		{
			var response = new BaseResponse<List<DetalleMaestroResponse>>();
			try
			{
				var resultado = await _maestroRepositorio.ListAsync(
					predicado: p => p.Codigo == codigoPadre && p.Estado,
					selector: p => p.MaestroDetalles);

				response.Data = _mapper.Map<List<DetalleMaestroResponse>>(resultado.FirstOrDefault());
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}
