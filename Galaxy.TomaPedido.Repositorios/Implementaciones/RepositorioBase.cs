using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Entidades;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Galaxy.TomaPedido.Repositorios.Implementaciones
{
	public class RepositorioBase<TEntidad> : IRepositorioBase<TEntidad> where TEntidad : EntidadBase
	{
		protected readonly BdpedidosContext _bdPedidoContext;

		public RepositorioBase(BdpedidosContext bdPedidoContext)
		{
			_bdPedidoContext = bdPedidoContext;
		}

		public async Task<ICollection<TEntidad>> ListAsync()
		{
			var resultado = await _bdPedidoContext.Set<TEntidad>()
				.Where(x => x.Estado == true)
				.AsNoTracking()
				.ToListAsync();

			return resultado;
		}

		public async Task<ICollection<TEntidad>> ListAsync(Expression<Func<TEntidad, bool>> predicado)
		{
			var resultado = await _bdPedidoContext.Set<TEntidad>()
				.Where(predicado)
				.AsNoTracking()
				.ToListAsync();

			return resultado;
		}

		public async Task<ICollection<TResult>> ListAsync<TResult>(
			Expression<Func<TEntidad, bool>> predicado,
			Expression<Func<TEntidad, TResult>> selector)
		{
			var resultado = await _bdPedidoContext.Set<TEntidad>()
				.Where(predicado)
				.AsNoTracking()
				.Select(selector)
				.ToListAsync();

			return resultado;
		}

		public async Task<(ICollection<TResult> Collection, int TotalRegistro)> ListAsync<TResult, Tkey>(
			Expression<Func<TEntidad, bool>> predicado,
			Expression<Func<TEntidad, TResult>> selector,
			Expression<Func<TEntidad,Tkey>> orderBy,
			int pagina = 1,
			int filas = 5)
		{
			try
			{
				var resultado = await _bdPedidoContext.Set<TEntidad>()
					.Where(predicado)
					.AsNoTracking()
					.OrderBy(orderBy)
					.Skip((pagina - 1) * filas)
					.Take(filas)
					.Select(selector)
					.ToListAsync();

				var totalRegistros = await _bdPedidoContext.Set<TEntidad>()
					.Where(predicado)
					.CountAsync();				
			
				return (resultado, totalRegistros);
			}
			catch (TaskCanceledException ex)
			{
				Console.WriteLine($"Task was canceled: {ex.Message}");
				throw;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				throw;
			}			
		}

		public async Task<TEntidad?> FindAsync(int id)
		{
			var resultado = await _bdPedidoContext.Set<TEntidad>()
				.FirstOrDefaultAsync(p => p.Id == id && p.Estado);

			return resultado;
		}

		public async Task<TEntidad> AddAsync(TEntidad entidad)
		{
			var resultado = await _bdPedidoContext.Set<TEntidad>()
				.AddAsync(entidad);

			await _bdPedidoContext.SaveChangesAsync();

			return resultado.Entity;
		}

		public async Task UpdateAsync()
		{
			await _bdPedidoContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			//var entidad = await _bdPedidoContext.Set<TEntidad>()
			//	.FirstOrDefaultAsync(p => p.Id == id);

			//if (entidad != null)
			//{
			//	entidad.Estado = false;
			//	await _bdPedidoContext.SaveChangesAsync();
			//}

			// Otra forma de hacerlo
			await _bdPedidoContext.Set<TEntidad>()
				.Where(p => p.Id == id)
				.ExecuteUpdateAsync(p => p.SetProperty(p => p.Estado, false));
		}		
	}
}
