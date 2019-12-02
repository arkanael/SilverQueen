using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SilverQueen.Presentation.Infra.Contracts;
using SilverQueen.Presentation.Infra.Repositories;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;

namespace SilverQueen.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IProdutoRepository, ProdutoRepository>();

            services.AddMediatR(typeof(Startup));

            #region Swagger

            services.AddSwaggerGen(
                         swagger =>
                         {
                             swagger.SwaggerDoc("v1",
                                 new Info
                                 {
                                     Title = "API de controle de Produtos",
                                     Version = "v1",
                                     Description = "Projeto desenvolvido em .NET CORE"
                                 });
                         }
                         );
            #endregion

            #region CORS
            services.AddCors(c => c.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyMethod();
                }


                ));
            #endregion


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvc();
            app.UseCors("DefaultPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Pojeto ASP.NET CORE 2.2 WEB API");
            });
        }
    }
}
