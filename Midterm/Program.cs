using Midterm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//TODO: Add loading of JSON/Sample.json configuration file here (will change to actual Midterm.json file later)


//TODO: Register configuration mapping of "MidtermExam" section in configuration to a MidtermExam object


var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
