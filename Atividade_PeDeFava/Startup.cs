﻿using Atividade_PeDeFava.Business.implementacoes;
using Atividade_PeDeFava.Business.interfaces;
using Atividade_PeDeFava.Context;
using Atividade_PeDeFava.Repository.implementacoes;
using Atividade_PeDeFava.Repository.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Swagger;

namespace Atividade_PeDeFava
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_configuration["AppConfig:Version"],
                    new Info
                    {
                        Title = _configuration["AppConfig:AppName"],
                        Version = _configuration["AppConfig:Version"]
                    });
            });

            var connectionString = _configuration["ConnectionString:SqlConnectionString"];
            services.AddDbContext<RestauranteContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClienteBusiness, ClienteBusiness>();
            services.AddScoped<IConsumoClienteBusiness, ConsumoClienteBusiness>();
            services.AddScoped<IRefeicaoBusiness, RefeicaoBusiness>();
            services.AddScoped<IR_Refeicao_ConsumoClienteBusiness, R_Refeicao_ConsumoClienteBusiness>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IConsumoClienteRepository, ConsumoClienteRepository>();
            services.AddScoped<IRefeicaoRepository, RefeicaoRepository>();
            services.AddScoped<IR_Refeicao_ConsumoClienteRepository, R_Refeicao_ConsumoClienteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint($"/swagger/{_configuration["AppConfig:Version"]}/swagger.json", _configuration["AppConfig:AppName"]);
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller}/{id?}");
            });
        }
    }
}
