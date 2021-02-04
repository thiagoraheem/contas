using Contas.Domain.Models;
using Contas.Domain.Repositories;
using Contas.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Persistence.Repositories
{
	public class ContasAPagarRepository : BaseRepository, IContasAPagarRepository
	{
		public ContasAPagarRepository(DataBaseContext context) : base(context) { }

		public async Task AddAsync(ContasAPagar conta)
		{
			await _context.AddAsync(conta);

			_context.SaveChanges();

		}

		public async Task<ContasAPagar> FindByIdAsync(int id)
		{
			return await _context.ContasAPagar.FindAsync(id);
		}

		public async Task<IEnumerable<ContasAPagar>> ListAsync()
		{
			return await _context.ContasAPagar.ToListAsync();
		}

		public void Remove(ContasAPagar conta)
		{
			_context.ContasAPagar.Remove(conta);
		}

		public void Update(ContasAPagar conta)
		{
			_context.ContasAPagar.Update(conta);
		}
	}
}
