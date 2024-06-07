using CoffeeShopApp.Hubs;
using CoffeeShopApp.Services;

namespace CoffeeShopApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IOrderService, OrderService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSignalR()
             .AddMessagePackProtocol();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Coffee}/{action=Index}/{id?}");

            app.MapHub<CoffeeHub>("/coffeeHub");

           app.Run();
        }
    }
}
