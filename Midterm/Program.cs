using Midterm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//TODO: Add loading of JSON/Sample.json configuration file here (will change to actual Midterm.json file later)
builder.Configuration.AddJsonFile("./JSON/MidtermQuestions.json", optional: false, reloadOnChange: true);

//TODO: Register configuration mapping of "MidtermExam" section in configuration to a MidtermExam object
builder.Services.Configure<MidtermExam>(builder.Configuration.GetSection("MidtermExam"));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
