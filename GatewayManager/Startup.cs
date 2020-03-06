using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using GatewayManager.Persistence.Contexts;
using GatewayManager.Domain.Services;
using GatewayManager.Domain.Repositories;
using GatewayManager.Persistence.Repositories;
using GatewayManager.Services;
using GatewayManager.Mapping;

namespace GatewayManager
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddMvcOptions(option => {
                option.EnableEndpointRouting = false;
            });



            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddDbContext<GatewayManagerContext>(options =>
            {
                options.UseInMemoryDatabase("gateways-store-in-memory");
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Angular/dist";
            });

            services.AddScoped(typeof(IGatewayRepository), typeof(GatewayRepository));
            services.AddScoped(typeof(IPeripheralDeviceRepository), typeof(PeripheralDeviceRepository));
            services.AddScoped(typeof(IGatewayService), typeof(GatewayService));
            services.AddScoped(typeof(IPeripheralDeviceService), typeof(PeripheralDeviceService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

        }
    }
}
