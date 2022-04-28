using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<SportDbContext>();

            services.AddTransient<IRepository<Sport>, SportRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();

            services.AddTransient<ISportLogic, SportLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IProductLogic, ProductLogic>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
