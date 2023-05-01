using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WatchParty.Areas.Identity.Data;
using WatchParty.DAL.Abstract;
using WatchParty.DAL.Concrete;
using WatchParty.Data;
using WatchParty.Models;
using WatchParty.Models.Concrete;
using WatchParty.Services.Abstract;
using WatchParty.Services.Concrete;
using WatchParty.Utilities;

namespace WatchParty;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var tmdbKey = builder.Configuration["TMDB:APIKey"];
        var sendGridKey = builder.Configuration["SendGrid:APIKey"];

        // Add services to the container.

        var watchPartyConnectionString = builder.Configuration.GetConnectionString("WatchPartyConnection") ?? throw new InvalidOperationException("Connection string 'WatchPartyConnection' not found.");
        var authConnectionString = builder.Configuration.GetConnectionString("AuthConnection") ?? throw new InvalidOperationException("Connection string 'AuthConnection' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(authConnectionString));

        builder.Services.AddDbContext<WatchPartyDbContext>(options => options.UseLazyLoadingProxies()
            .UseSqlServer(watchPartyConnectionString));

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })

            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<DbContext, WatchPartyDbContext>();
        builder.Services.AddScoped<ITMDBService, TMDBService>(s => new TMDBService(tmdbKey, new TMDBClient { BaseAddress = new Uri("https://api.themoviedb.org/3") }));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IWatcherRepository, WatcherRepository>();
        builder.Services.AddScoped<IFollowingListRepository, FollowingListRepository>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        builder.Services.AddTransient<IEmailSender, SendGridService>(s => new SendGridService(builder.Configuration));
        builder.Services.AddScoped<IWatchListRepository, WatchListRepository>();
        builder.Services.AddScoped<IShowRepository, ShowRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IWatchListItemRepository, WatchListItemRepository>();
        builder.Services.AddScoped<IWatchPartyGroupRepository, WatchPartyGroupRepository>();
        builder.Services.AddScoped<IWatchPartyGroupAssignmentRepository, WatchPartyGroupAssignmentRepository>();
        builder.Services.AddScoped<INotificationRepository, NotificationRepository>();



        var app = builder.Build();

        // After Build has been called, all services have been registered (by running Startup)
        // By using a scope for the services to be requested below, we limit their lifetime to this set of calls.
        // See: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0#call-services-from-main
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                // Get the IConfiguration service that allows us to query user-secrets and 
                // the configuration on Azure
                var config = app.Services.GetRequiredService<IConfiguration>();
                // Set password with the Secret Manager tool, or store in Azure app configuration
                // dotnet user-secrets set SeedUserPW <pw>

                var testUserPw = config["SeedUserPW"];
                var adminPw = config["SeedAdminPW"];

                SeedUsers.Initialize(services, SeedData.UserSeedData, testUserPw).Wait();
                SeedUsers.InitializeAdmin(services, "admin@example.com", "admin", adminPw, "The", "Admin").Wait();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

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
            name: "AddMovieToWatchList",
            pattern: "watchlist/addMovieToWatchList",
            defaults: new { controller = "WatchList", action = "addMovieToWatchList" });

        app.MapControllerRoute(
            name: "AddShowToWatchList",
            pattern: "watchlist/addShowToWatchList",
            defaults: new { controller = "WatchList", action = "addShowToWatchList" });

        app.MapControllerRoute(
            name: "watchList",
            pattern: "watchlist/{username}",
            defaults: new { controller = "WatchList", action = "Index" });

        app.MapControllerRoute(
           name: "editProfile",
           pattern: "user/edit/{username}",
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
