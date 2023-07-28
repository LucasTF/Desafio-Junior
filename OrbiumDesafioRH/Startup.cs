using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrbiumDesafioRH.Converters;
using OrbiumDesafioRH.Models.Context;
using OrbiumDesafioRH.Repositories.Contracts;
using OrbiumDesafioRH.Repositories.Implementations;
using OrbiumDesafioRH.Services.Contracts;
using OrbiumDesafioRH.Services.Implementations;
using OrbiumDesafioRH.Settings;

namespace OrbiumDesafioRH
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            services.AddDbContext<RhContext>(options => 
            options.UseSqlite("Data Source=Database.db;"));
            // Repositories
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            // Services
            services.AddTransient<IHumanResourcesService, HumanResourcesService>();
            services.AddHttpClient<IHttpClientService, HttpClientService>();
            // Converters
            services.AddTransient<EmployeeConverter, EmployeeConverter>();
            // Settings
            services.Configure<AppSettings>(Configuration.GetSection("MySettings"));
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowAnyHeader();
                });
            });
            // MVC
            services.AddControllersWithViews();
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
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "rh",
                    pattern: "{controller=Rh}/{action=Index}");
            });
        }
    }
}
