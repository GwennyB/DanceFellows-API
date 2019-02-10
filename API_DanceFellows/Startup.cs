using API_DanceFellows.Data;
using API_DanceFellows.Models.Interfaces;
using API_DanceFellows.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;


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
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Dance Fellows API";
                    document.Info.Description = "A source for West Coast Swing competitors and competition data";
                    document.Info.TermsOfService = "N/A";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Dance Fellows",
                        Email = string.Empty,
                        Url = "https://github.com/GwennyB/DanceFellows-API"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "GNU General Public License v3.0",
                        Url = "https://github.com/GwennyB/DanceFellows-API/blob/master/LICENSE"
                    };
                };
            });

            services.AddDbContext<API_DanceFellowsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            services.AddScoped<ICompetitorManager, CompetitorManagementService>();
            services.AddScoped<IResultManager, ResultManagementService>();

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

            // serve static files (needed?)
            app.UseStaticFiles();

            /// <summary>
            /// defines routing template
            /// </summary>
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}");
            });

            // use Swagger for route documentation
            app.UseSwagger();
            app.UseSwaggerUi3();


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
