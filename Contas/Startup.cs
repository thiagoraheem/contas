using Contas.Domain.Repositories;
using Contas.Domain.Services;
using Contas.Persistence.Contexts;
using Contas.Persistence.Repositories;
using Contas.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contas
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// usado para testar o aplicativo sem banco de dados real
			//services.AddDbContext<DataBaseContext>(options => { options.UseInMemoryDatabase("dtb_Contas"); });

			// usado para conectar ao banco de dados por string de conexão
			services.AddDbContext<DataBaseContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("dtb_Contas")); });

			services.AddScoped<IContasAPagarRepository, ContasAPagarRepository>();
			services.AddScoped<IContasAPagarService, ContasAPagarService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
