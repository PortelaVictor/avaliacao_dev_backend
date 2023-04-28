using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Vectra.Avaliacao.Backend.Context;
using Vectra.Avaliacao.Backend.Application;
using Vectra.Avaliacao.Backend.Application.DTOs;
using Vectra.Avaliacao.Backend.Application.Interfaces;
using Vectra.Avaliacao.Backend.Application.Interfaces.Interfaces;
using Vectra.Avaliacao.Backend.Application.Contratos;
using AutoMapper;
using System;

namespace Vectra.Avaliacao.Backend
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vectra.Avaliacao.Backend.API", Version = "v1" });
            });

            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
            });

            services.AddDbContext<EFContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
                opt.UseLazyLoadingProxies();
            });

            

            services.AddTransient<IEFContext, EFContext>();
            services.AddScoped<IResponse, Response>();
            services.AddScoped<IContaService, ContaService>();
            services.AddCors(config =>
            {
                config.AddPolicy("hosts", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()) ;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("hosts");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vectra.Avaliacao.Backend v1"));
            }

            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader()
                        );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
