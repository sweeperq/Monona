using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Monona.Data;
using Monona.Services;
using Monona.Web.Models.Products;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Monona.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                // Add all mapping profiles defined in Web or Services
                cfg.AddProfiles("Monona.Web", "Monona.Services");

                cfg.CreateMissingTypeMaps = false;

                // Do not map properties marked as [ReadOnly(true)]
                cfg.ForAllPropertyMaps(map =>
                    map.SourceMember == null || map.SourceMember.GetCustomAttributes().OfType<ReadOnlyAttribute>().Any(x => x.IsReadOnly),
                    (map, config) => config.Ignore()
                );
            });

            services.AddDbContext<MononaDbContext>(cfg => cfg.UseSqlServer(Configuration.GetConnectionString("MononaConnection")));

            services.AddScoped(typeof(GenericService<,>));
            services.AddScoped<CountryService>();
            

            services.AddResponseCompression(cfg => cfg.EnableForHttps = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseResponseCompression();

            app.UseStaticFiles(new StaticFileOptions
            {
                // Cache static files for 30 days
                OnPrepareResponse = (x) =>
                    x.Context.Response.Headers.Add(HeaderNames.CacheControl, "public,max-age=2592000")
            });

            app.UseDefaultFiles();

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                cfg.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
