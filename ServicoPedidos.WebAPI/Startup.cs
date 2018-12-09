﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServicoPedidos.Dominio;
using ServicoPedidos.Dominio.Abstracoes;
using ServicoPedidos.Infra.Contextos;
using ServicoPedidos.Infra.Repositorios;
using ServicoPedidos.WebAPI.JsonConverters;

namespace ServicoPedidos.WebAPI
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
            
            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver = new JsonContractResolverPadrao();
                    });

            services.AddDbContext<ContextoPedidos>(options => options.UseSqlServer(Configuration.GetConnectionString("ConexaoPedidos")));

            services.AddScoped<IDiretorDeRequisicoesDePedidos, DiretorDeRequisicoesDePedidos>();
            services.AddScoped<IConversorDeDTOs, ConversorDeDTOs>();
            services.AddScoped<IRepositorioDePedidos, RepositorioDePedidos>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
