using AutoMapper;
using Galaxy.TomaPedido.Comun;
using Galaxy.TomaPedido.Dto.Request.Clientes;
using Galaxy.TomaPedido.Dto.Response;
using Galaxy.TomaPedido.Dto.Response.Clientes;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Galaxy.TomaPedido.Servicio.Interfaces;

namespace Galaxy.TomaPedido.Servicio.Implementaciones
{
	public class ClienteServicio : IClienteServicio
	{
		private readonly IClienteRepositorio _clienteRepositorio;
		private readonly IMapper _mapper;

		public ClienteServicio(IClienteRepositorio clienteRepositorio, IMapper mapper)
		{
			_clienteRepositorio = clienteRepositorio;
			_mapper = mapper;
		}

		public async Task<BaseResponse> Registrar(ClienteRequestDto clienteRequestDto)
		{
			var response = new BaseResponse();

			try
			{
				var cliente = _mapper.Map<Cliente>(clienteRequestDto);

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

		public async Task<BaseResponse> Actualizar(int id, ClienteRequestDto requestDto)
		{
			var response = new BaseResponse();

			try
			{
				var cliente = await _clienteRepositorio.FindAsync(id);
				if (cliente == null)
				{
					throw new InvalidCastException("Cliente no encontrado");
				}

				_mapper.Map(requestDto, cliente);

				await _clienteRepositorio.UpdateAsync();

				response.Message = "Cliente actualizado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<BaseResponse<ClienteResponseDto>> ObtenerPorId(int id)
		{
			var response = new BaseResponse<ClienteResponseDto>();

			try
			{
				var cliente = await _clienteRepositorio.FindAsync(id);
				if (cliente == null)
				{
					throw new InvalidCastException("Cliente no encontrado");
				}

				response.Data = _mapper.Map<ClienteResponseDto>(cliente);
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<BaseResponse> Eliminar(int id)
		{
			var response = new BaseResponse();

			try
			{
				var cliente = await _clienteRepositorio.FindAsync(id);
				if (cliente == null)
				{
					throw new InvalidCastException("Cliente no encontrado");
				}

				await _clienteRepositorio.DeleteAsync(id);

				response.Message = "Cliente eliminado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
			}

			return response;
		}

		public async Task<PaginacionResponse<ListaClientesResponseDto>> Listar(BusquedaClientesRequest request)
		{
			var response = new PaginacionResponse<ListaClientesResponseDto>();

			try
			{
				var resultado = await _clienteRepositorio.ListAsync(
					predicado: p => p.Estado == true &&
						(string.IsNullOrEmpty(request.RazonSocial) || p.RazonSocial.Contains(request.RazonSocial)) &&
						(string.IsNullOrEmpty(request.Ruc) || p.NumeroDocumento.Contains(request.Ruc)),
					selector: p => new ListaClientesResponseDto
					{
						Celular = p.Celular,
						Contacto = p.Contacto,
						CorreoElectronico = p.CorreoElectronico,
						Direccion = p.Direccion,
						Id = p.Id,
						NumeroDocumento = p.NumeroDocumento,
						RazonSocial = p.RazonSocial,
						Rubro = p.IdRubroMaeNavigation.Valor!
					},
					orderBy: p => p.RazonSocial,
					pagina: request.Pagina,
					filas: request.Filas);


				//selector: p => _mapper.Map<ListaClientesResponseDto>(p),

				response.Data = resultado.Collection;
				response.Success = true;
				response.TotalFilas = resultado.TotalRegistro;
				response.TotalPaginas = Helpers.CalcularNumeroPaginas(resultado.TotalRegistro, request.Filas);
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
