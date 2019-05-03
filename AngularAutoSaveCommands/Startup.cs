using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AngularAutoSaveCommands.Providers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AngularAutoSaveCommands.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace AngularAutoSaveCommands
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
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMsSqlServerProvider");


            services.AddDbContext<DomainModelMsSqlServerContext>(options =>
                options.UseSqlServer(sqlConnectionString)
            );

            services.AddScoped<ValidateCommandDtoFilter>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<ICommandDataAccessProvider, CommandDataAccessProvider>();
            services.AddScoped<ICommandHandler, CommandHandler>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            var angularRoutes = new[] {
                 "/home",
                 "/about",
                 "/httprequests",
                 "/commands"
             };

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.HasValue && null != angularRoutes.FirstOrDefault(
                    (ar) => context.Request.Path.Value.StartsWith(ar, StringComparison.OrdinalIgnoreCase)))
                {
                    context.Request.Path = new PathString("/");
                }

                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
