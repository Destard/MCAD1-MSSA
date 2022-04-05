using DemoMVCCoreWebApp.Hubs;
using DemoMVCCoreWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IChaseGame>(new ChaseGame());
builder.Services.AddHostedService<ChaseGameBackgroundService>();
builder.Services.AddSingleton<IVisitorCounter>(new VisitorCounter()); //Registering.
//A singleton service allows me to pass a single instance of a class across all interactions of my web application.

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

app.Use(async (context, next) =>
{
    //Anything I write in this App.Use method call is "middleware".
    //In middleware, we have complete control over the Request/Response pipeline.
    //We can read anything the user has submitted for their request (Path, Verb, Cookies, Browser User Agent,Form Details)
    string queryStringName = context.Request.Query["name"];
    //We can also fully provide values to the HTTP Response.
    if (queryStringName != null)
    {
        await context.Response.WriteAsync($"You sent a message and you provided a name {queryStringName}!");
        //I'm NOT calling next.Invoke() here, which means the pipeline is prematurely ended.
    }
    else
    {
        await next.Invoke();
    }
});

app.MapHub<ChaseHub>("/chaseHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
