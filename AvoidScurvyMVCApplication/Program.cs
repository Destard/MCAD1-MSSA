using AvoidScurvyMVCApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders()
    //.AddConfiguration(builder.Configuration.GetSection("Logging"))
    .AddDebug();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AvoidScurvyContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AvoidScurvyContext")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<AvoidScurvyContext>();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddAuthentication()
    .AddDiscord(options =>
    {
        options.ClientId = builder.Configuration["DiscordClientId"];
        options.ClientSecret = builder.Configuration["DiscordClientSecret"];
    });

builder.Services.AddScoped<IProductRepository, DBContextProductRepository>();


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
app.MapRazorPages();

app.Run();
