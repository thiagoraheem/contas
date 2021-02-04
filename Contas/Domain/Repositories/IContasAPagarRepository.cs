using Contas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Domain.Repositories
{
	public interface IContasAPagarRepository
	{

		Task<IEnumerable<ContasAPagar>> ListAsync();
		Task AddAsync(ContasAPagar conta);
		Task<ContasAPagar> FindByIdAsync(int id);
		void Update(ContasAPagar conta);
		void Remove(ContasAPagar conta);


	}
}
