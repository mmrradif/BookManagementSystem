using Microsoft.EntityFrameworkCore;
using PracticalExam.Database_Context;
using PracticalExam.Database_Models;
using PracticalExam.Interfaces;
using PracticalExam.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PracticalExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            // Add Services
            builder.Services.AddDbContext<BookDbContext>(); // For Create Database
            builder.Services.AddTransient<IAll<Book>,BookRepo>();

            



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
                pattern: "{controller=Book}/{action=Index}/{id?}");

            app.Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        //{
        //    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
        //    webBuilder.UseWebRoot("wwwroot");
        //});
    }
}