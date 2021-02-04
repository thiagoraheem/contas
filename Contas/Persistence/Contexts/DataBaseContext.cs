using Contas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Persistence.Contexts
{
	public class DataBaseContext : DbContext
	{

		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

		public DbSet<ContasAPagar> ContasAPagar { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<ContasAPagar>(entity => { 
				entity.ToTable("ContasAPagar");
				entity.HasKey(x => x.idConta);
				entity.Property(x => x.idConta).IsRequired().ValueGeneratedOnAdd();
				entity.Property(x => x.Nome).IsRequired().HasMaxLength(50).IsFixedLength(false).IsUnicode(false);
				entity.Property(x => x.Valor).IsRequired().HasColumnType("decimal(14, 2)");
				entity.Property(x => x.DataVencimento).IsRequired().HasColumnType("datetime");
				entity.Property(x => x.DataPagamento).IsRequired().HasColumnType("datetime");

				entity.HasData(
					new ContasAPagar() { idConta = 1, Nome = "Teste de conta a pagar", Valor = 100, DataVencimento = new DateTime(2021, 2, 5), DataPagamento = new DateTime(2021, 2, 5) },
					new ContasAPagar() { idConta = 2, Nome = "Teste de conta a pagar", Valor = 200, DataVencimento = new DateTime(2021, 2, 4), DataPagamento = new DateTime(2021, 2, 5) }
				);
			});

		}

	}
}
