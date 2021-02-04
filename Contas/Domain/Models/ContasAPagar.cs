using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Domain.Models
{
	public class ContasAPagar
	{
		public int idConta { get; set; }
		public string Nome { get; set; }
		public decimal Valor { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime DataPagamento { get; set; }

		[NotMapped]
		public double DiasAtraso
		{
			get
			{
				var dif = DataPagamento.Subtract(DataVencimento);
				if (dif.TotalDays < 0) return 0;
				else return dif.TotalDays;
			}
		}

		[NotMapped]
		public decimal ValorCorrigido
		{
			get
			{

				decimal multa = 0;
				decimal juros = 0;

				if(DiasAtraso > 0 && DiasAtraso <= 3)
				{
					multa = Valor * 0.02m;
					juros = (Valor * 0.001m) * (decimal)DiasAtraso;
				}
				if (DiasAtraso > 3 && DiasAtraso <= 5)
				{
					multa = Valor * 0.03m;
					juros = (Valor * 0.002m) * (decimal)DiasAtraso;
				}
				if (DiasAtraso > 5)
				{
					multa = Valor * 0.05m;
					juros = (Valor * 0.003m) * (decimal)DiasAtraso;
				}


				return Valor + multa + juros;


			}
		}


	}
}
