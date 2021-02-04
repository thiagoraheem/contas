using Contas.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Persistence.Repositories
{
	public class BaseRepository
	{

		protected readonly DataBaseContext _context;

		public BaseRepository(DataBaseContext context)
		{
			_context = context;
		}

	}
}
