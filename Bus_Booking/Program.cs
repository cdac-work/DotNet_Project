using Microsoft.EntityFrameworkCore;
using rashi_try.Models;

namespace bus_book
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BusBookingContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("BusBookingContext")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Buses}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
