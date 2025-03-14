using Galaxy.TomaPedido.Dto.Request.Clientes;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Galaxy.TomaPedido.Servicio.Interfaces;

namespace Galaxy.TomaPedido.Servicio.Implementaciones
{
	public class ClienteServicio : IClienteServicio
	{
		private readonly IClienteRepositorio _clienteRepositorio;

		public ClienteServicio(IClienteRepositorio clienteRepositorio)
		{
			_clienteRepositorio = clienteRepositorio;
		}

		public async Task<BaseResponse> Registrar(ClienteRequestDto clienteRequestDto)
		{
			var response = new BaseResponse();

			try
			{
				Cliente cliente = new()
				{
					RazonSocial = clienteRequestDto.RazonSocial,
					NumeroDocumento = clienteRequestDto.NumeroDocumento,
					Celular = clienteRequestDto.Celular,
					Contacto = clienteRequestDto.Contacto,
					CorreoElectronico = clienteRequestDto.CorreoElectronico,
					Direccion = clienteRequestDto.Direccion,
					IdRubroMae = clienteRequestDto.IdRubroMae
				};

				await _clienteRepositorio.AddAsync(cliente);

				response.Message = "Cliente registrado correctamente";
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
