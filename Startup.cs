using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;
using Microsoft.AspNetCore.Http;
using Shop.Data.Models;

namespace Shop
{
    public class Startup
    {

        private IConfigurationRoot _confSting;

        [System.Obsolete]
        public Startup(IHostingEnvironment hostEnv)
        {
            _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbSettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)// подключение служб
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars,CarRepository>(); // указываем какой интерфейс и реализующий класс этого интерфейса
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMemoryCache();

            services.AddMvc(option => option.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // условия запуска
        {
            app.UseDeveloperExceptionPage();// отображать страницу с ошибками
            app.UseStatusCodePages();// показывать коды страниц типа (404,200)
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });

            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);

            }
        }
    }
}
