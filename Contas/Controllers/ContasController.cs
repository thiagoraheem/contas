using Contas.Domain.Models;
using Contas.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Contas.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ContasController : ControllerBase
	{
		private readonly IContasAPagarService _contasService;

		public ContasController(IContasAPagarService contasService)
		{
			_contasService = contasService;
		}

		[HttpGet]
		public async Task<IEnumerable<ContasAPagar>> GetAll()
		{

			var contas = await _contasService.ListASync();

			return contas;

		}

		[HttpPost]
		public IActionResult NovaContaAPagar([FromBody] dynamic json)
		{

			try
			{
				var conta = JsonConvert.DeserializeObject<ContasAPagar>(Convert.ToString(json), new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

				if (String.IsNullOrEmpty(conta.Nome))
				{
					return new JsonResult(new { Resultado = false, Mensagem = "O Nome da conta deve ser informado!" });
				}
				if (conta.Valor == 0)
				{
					return new JsonResult(new { Resultado = false, Mensagem = "Um valor maior que zero deve ser informado!" });
				}
				if (conta.DataVencimento == null || conta.DataVencimento == new DateTime())
				{
					return new JsonResult(new { Resultado = false, Mensagem = "A data de vencimento deve ser informada!" });
				}
				if (conta.DataPagamento == null || conta.DataPagamento == new DateTime())
				{
					return new JsonResult(new { Resultado = false, Mensagem = "A data de pagamento deve ser informada!" });
				}

				_contasService.AddAsync(conta);

				return new JsonResult(new { Resultado = true, Mensagem = "Registro criado com sucesso!" });
			}
			catch (Exception ex)
			{
				return new JsonResult(new { Resultado = false, Mensagem = $"Erro ao gravar! {ex.Message}" });
			}


		}
	}
}
