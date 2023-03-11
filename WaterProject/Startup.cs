using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // Since we started with an empty, This is what makes it use the controllers and views
            services.AddDbContext<WaterProjectContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:WaterDBConnection"]);
           });
            services.AddScoped<IWaterProjectRepository, EFWaterProjectRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();

            // If basket has already been set up it will grab it. If not, it will create a new one
            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); // Use WWWroot
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            // the order of these matters. The first one matches, it'll run. Doesn't matter if there's more.
            {
                endpoints.MapControllerRoute("typepage","{projectType}/Page_{page_num}",
                new {Controller = "Home", action = "Index"});
                
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page_{page_num}",
                    defaults: new { Controller = "Home", action = "Index", page_num = 1 });

                endpoints.MapControllerRoute("type", "{projectType}",
                    new { Controller = "Home", action = "Index", page_num = 1 });

                

                endpoints.MapDefaultControllerRoute(); // Controller, Action, ID route. We previously wrote it out
                endpoints.MapRazorPages();
            });
        }
    }
}
