using IMusic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using IMusic.Env;
using IMusic.Repositories;
using IMusic.Services;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load("../.env");
builder.Configuration.AddEnvironmentVariables();

// Load database connection string
var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

//var firebaseApiKey = Environment.GetEnvironmentVariable("FIREBASE_API_KEY");
//var firebaseAuthDomain = Environment.GetEnvironmentVariable("FIREBASE_AUTH_DOMAIN");
//var firebaseProjectId = Environment.GetEnvironmentVariable("FIREBASE_PROJECT_ID");
//var firebaseStorageBucket = Environment.GetEnvironmentVariable("FIREBASE_STORAGE_BUCKET");
//var firebaseMessagingSenderId = Environment.GetEnvironmentVariable("FIREBASE_MESSAGING_SENDER_ID");
//var firebaseAppId = Environment.GetEnvironmentVariable("FIREBASE_APP_ID");
//var firebaseAuthEmail = Environment.GetEnvironmentVariable("FIREBASE_AUTH_EMAIL");
//var firebaseAuthPassword = Environment.GetEnvironmentVariable("FIREBASE_AUTH_PASSWORD");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Redirect to login if not 
            });

builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure identity options (password requirements, lockout settings, etc.)
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

    // Lockout settings
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;

    // User settings
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddSingleton(new FirebaseStorageService(
        Environment.GetEnvironmentVariable("FIREBASE_API_KEY"),
        Environment.GetEnvironmentVariable("FIREBASE_STORAGE_BUCKET"),
        Environment.GetEnvironmentVariable("FIREBASE_AUTH_EMAIL"),
        Environment.GetEnvironmentVariable("FIREBASE_AUTH_PASSWORD")
    ));
builder.WebHost.UseStaticWebAssets();

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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

