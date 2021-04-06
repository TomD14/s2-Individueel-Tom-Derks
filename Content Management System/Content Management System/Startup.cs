using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Content_Management_System.Models;

namespace Content_Management_System
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
            services.AddMvc();
<<<<<<< HEAD
            services.Add(new ServiceDescriptor(typeof(LampContext), new LampContext(Configuration.GetConnectionString("DefaultConnection"))));
=======
<<<<<<< HEAD
            services.Add(new ServiceDescriptor(typeof(LampContext), new LampContext(Configuration.GetConnectionString("DefaultConnection"))));
=======
            //services.Add(new ServiceDescriptor(typeof(LampContext), new LampContext(Configuration.GetConnectionString("DefaultConnection"))));
            services.AddTransient<AppDB>(_ => new AppDB(Configuration["ConnectionStrings:DefaultConnection"]));
>>>>>>> 9af3c46d62a1e89e9db0e7a8d0cdc9562b6c3e0f
>>>>>>> c14375f6eaa5b10655c6fe58eb79ff5e5f17e0af
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
