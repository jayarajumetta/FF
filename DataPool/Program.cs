using DataPool.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Resolve data file path — defaults to data/quotes.json beside the project.
// Override with "DataPool:FilePath" in appsettings.json or an environment variable.
var dataFilePath = builder.Configuration["DataPool:FilePath"];
if (string.IsNullOrEmpty(dataFilePath))
    dataFilePath = "data/quotes.json";

if (!Path.IsPathRooted(dataFilePath))
    dataFilePath = Path.Combine(builder.Environment.ContentRootPath, dataFilePath);

builder.Services.AddSingleton<IDataPoolService>(_ => new DataPoolService(dataFilePath));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Run();
