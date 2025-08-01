using Microsoft.EntityFrameworkCore;
using URL_Shortener.Data;

namespace URL_Shortener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Container
            builder.Services.AddDbContext<UrlContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Url}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
