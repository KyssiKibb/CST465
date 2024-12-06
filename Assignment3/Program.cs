using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Assignment3;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDataEntityRepository<BlogPost>, BlogDBRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();