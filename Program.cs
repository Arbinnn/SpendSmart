using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpendSmart.Models;

namespace SpendSmart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDbContext<ExpensesDB>(options =>
            //options.UseInMemoryDatabase("SpendSmartDb")
            //);

            //builder.Services.AddDbContext<ExpensesDB>(options =>
            //options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Orchid;Trusted_Connection=True;"));

            // Fix the connection string retrieval
            builder.Services.AddDbContext<ExpensesDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

            );



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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
