var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync($"You navigated to the following path:{context.Request.Path}");
    if (context.Request.Path == "/SecretPath")
    {
        await context.Response.WriteAsync
            ("You navigated to the secret path! I will no longer execute the next block of middleware.");
    }
    else
    {
        await next.Invoke();
    }
});
app.Run(async (context) =>
{
    //Anything I write in this App.Use method call is "middleware".
    //In middleware, we have complete control over the Request/Response pipeline.
    //We can read anything the user has submitted for their request (Path, Verb, Cookies, Browser User Agent,Form Details)
    string queryStringName = context.Request.Query["name"];
    //We can also fully provide values to the HTTP Response.
    if (queryStringName != null)
    {
        await context.Response.WriteAsync($"You sent a message and you provided a name {queryStringName}!");
    }
    else
    {
        await context.Response.WriteAsync("You submitted a request with a name in the query string!");
    }
});
app.Run();