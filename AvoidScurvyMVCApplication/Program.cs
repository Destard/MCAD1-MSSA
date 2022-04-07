using AvoidScurvyMVCApplication.Models;
using AvoidScurvyMVCApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders()
    //.AddConfiguration(builder.Configuration.GetSection("Logging"))
    .AddDebug();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddResponseCaching();
builder.Services.AddDbContext<AvoidScurvyContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AvoidScurvyContext")));
builder.Services.AddDefaultIdentity<AvoidScurvyIdentityUser>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredUniqueChars = 5;
            options.Password.RequiredLength = 5;
            options.Password.RequireLowercase = false;
        })
    .AddEntityFrameworkStores<AvoidScurvyContext>();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddAuthentication()
    .AddDiscord(options =>
    {
        options.ClientId = builder.Configuration["DiscordClientId"];
        options.ClientSecret = builder.Configuration["DiscordClientSecret"];
    });

builder.Services.AddTransient<IProductRepository, DBContextProductRepository>();


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
app.UseResponseCaching();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
