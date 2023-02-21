using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchParty.Areas.Identity.Data;
using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Data;
using WatchParty.Models;
using WatchParty.Models.Concrete;
using WatchParty.Services.Abstract;
using WatchParty.Services.Concrete;

namespace WatchParty;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var tmdbKey = builder.Configuration["TMDB:APIKey"];

        // Add services to the container.

        var watchPartyConnectionString = builder.Configuration.GetConnectionString("WatchPartyConnection") ?? throw new InvalidOperationException("Connection string 'WatchPartyConnection' not found.");
        //builder.Services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(watchPartyConnectionString));

        var authConnectionString = builder.Configuration.GetConnectionString("AuthConnection") ?? throw new InvalidOperationException("Connection string 'AuthConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(authConnectionString));

        builder.Services.AddDbContext<WatchPartyDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(watchPartyConnectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();
        
		builder.Services.AddScoped<ITMDBService, TMDBService>(s => new TMDBService(tmdbKey, new TMDBClient {BaseAddress = new Uri("https://api.themoviedb.org/3") }));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IWatcherRepository, WatcherRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
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
           name: "editProfile",
           pattern: "user/edit",
           defaults: new { controller = "User", action = "Edit" });

        app.MapControllerRoute(
            name: "profile",
            pattern: "user/{username}",
            defaults: new { controller = "User", action = "Profile" });

        app.MapControllerRoute(
            name: "notfound",
            pattern: "user",
            defaults: new { controller = "User", action = "NotFound" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapRazorPages();

        app.Run();
    }
}
