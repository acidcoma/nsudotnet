using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab4.controller;
using lab4.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace lab4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
            services.AddMvc();

            //services.AddDbContext<Context>(options =>
              //  options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=dotnetdatabase;User Id=postgres;Password=postgres"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            
            // app.AddMvc() устанавливает компоненты MVC для обработки запроса и, в частности, настраивает систему маршрутизации в приложении.
        }
    }
}