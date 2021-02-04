using Contas.Domain.Models;
using Contas.Domain.Repositories;
using Contas.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Services
{
	public class ContasAPagarService : IContasAPagarService
	{
		private readonly IContasAPagarRepository _contasRepository;

		public ContasAPagarService(IContasAPagarRepository contasRepository)
		{
			_contasRepository = contasRepository;
		}

		public async Task AddAsync(ContasAPagar conta)
		{
			await _contasRepository.AddAsync(conta);
		}

		public async Task<IEnumerable<ContasAPagar>> ListASync()
		{
			return await _contasRepository.ListAsync();
		}
	}
}
