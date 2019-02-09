using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_DanceFellows
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Constructs startup object and maps Configuration
        /// </summary>
        /// <param name="configuration"> config properties set </param>
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        /// <summary>
        /// loads required dependencies and database build instructions (context and conn string)
        /// </summary>
        /// <param name="services"> collection of service descriptors </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<API_DanceFellowsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            // TODO: Register DB interface & service
            services.AddScoped<ICompetitorManager, CompetitorManagementService>();
            services.AddScoped<IEventManager, EventManagementService>();
            services.AddScoped<ICompetitionManager, CompetitionManagementService>();
            services.AddScoped<IResultManager, ResultManagementService>();
            services.AddScoped<ISeriesManager, SeriesManagementService>();
        }

        /// <summary>
        /// configures HTTP request pipeline
        /// </summary>
        /// <param name="app"> mechanisms to configure request pipeline </param>
        /// <param name="env"> defn of hosting environment </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // TODO: serve static files

            app.UseHttpsRedirection();
            app.UseMvc();
            /// <summary>
            /// defines default route - defn in HomeController
            /// </summary>
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
