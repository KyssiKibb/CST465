using Lab6;
using Lab6.Middleware;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<HeaderOptions>(builder.Configuration.GetSection("Headers"));

var app = builder.Build();

//app.UseConfiggedHeaders();
app.UseOregonTechRedirect();
app.MapDefaultControllerRoute();

app.Run();
