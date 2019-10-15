using CSTest.Data;
using CSTest.Data.Repository;
using CSTest.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSTest {
    public class Startup {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment env) {
            _confString = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IFileOperations, FileOperations>();
            services.AddTransient<IDateTemps, DateTempRepository>();
            services.AddTransient<IHouseNames, HouseRepository>();
            services.AddTransient<IHouseDetailes, HouseDetailRepository>();
            services.AddTransient<IPlantNames, PlantRepository>();
            services.AddTransient<IPlantDetailes, PlantDetailRepository>();
            services.AddMvc();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
