using ImagineArte.Aplicacao.Organizacao;
using ImagineArte.Aplicacao.Produtos;
using ImagineArte.Infra;
using ImagineArte.Infra.EntityFramework;
using ImagineArte.Repositorio.Organizacao;
using ImagineArte.Repositorio.Produtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoard.Api
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
            AdicionarDependencias(services);
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DashBoard.Api", Version = "v1" });
            });

            services.AddMvc();
        }

        private void AdicionarDependencias(IServiceCollection services)
        {
            services.AddDbContext<EntityFrameworkContexto>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ProdutoAplicacao, ProdutoAplicacao>();
            services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
            services.AddScoped<MarcaAplicacao, MarcaAplicacao>();
            services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
            services.AddScoped<DepartamentoAplicacao, DepartamentoAplicacao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DashBoard.Api v1"));
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseCors(option =>
            {
                option.AllowAnyOrigin();
                option.AllowAnyMethod();
                option.AllowAnyHeader();
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
