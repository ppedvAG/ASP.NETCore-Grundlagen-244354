using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Services;
using Microsoft.AspNetCore.Identity;

namespace DemoMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IRecipeServiceAsync, RecipeService>();
            builder.Services.AddTransient<IOrderServiceAsync, OrderService>();
            builder.Services.AddTransient<IFileService, RemoteFileService>();

            // Wir mappen die Einstellungen aus der appsettings.json nach FileServiceOptions
            var fileConfig = builder.Configuration.GetSection("FileServer");
            builder.Services.Configure<FileServiceOptions>(fileConfig);
            builder.Services.AddHttpClient();

            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddSqlServer<DeliveryDbContext>(connectionString);

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<DeliveryDbContext>();

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
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
