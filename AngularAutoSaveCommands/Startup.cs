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
            services.AddScoped<ICommandDataAccessProvider, CommandDataAccessProvider>();
            services.AddScoped<ICommandHandler, CommandHandler>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
				
            services.AddRazorPages().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

        }

        public void Configure(IApplicationBuilder app)
        {
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

            app.UseCors("AllowAllOrigins");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
