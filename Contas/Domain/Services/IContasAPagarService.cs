using Contas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Domain.Services
{
	public interface IContasAPagarService
	{

		Task<IEnumerable<ContasAPagar>> ListASync();

		Task AddAsync(ContasAPagar conta);
	}
}
