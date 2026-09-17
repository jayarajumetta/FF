using DataPool.Configuration;
using DataPool.Security;
using DataPool.Services;

var builder = WebApplication.CreateBuilder(args);
var runtimeOptions = DataPoolRuntimeOptions.FromConfiguration(builder.Configuration);
runtimeOptions.Validate();

builder.WebHost.UseUrls(runtimeOptions.ListenUrl);
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = runtimeOptions.MaxRequestBodyBytes;
});

builder.Services.AddSingleton(runtimeOptions);
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var dataFilePath = builder.Configuration["DataPool:FilePath"];
if (string.IsNullOrWhiteSpace(dataFilePath))
    dataFilePath = "data/quotes.json";

if (!Path.IsPathRooted(dataFilePath))
    dataFilePath = Path.Combine(builder.Environment.ContentRootPath, dataFilePath);

builder.Services.AddSingleton<IDataPoolService>(_ => new DataPoolService(dataFilePath));
builder.Services.AddHostedService<CleanupHostedService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseMiddleware<DataPoolRequestGuardMiddleware>();
app.UseRouting();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapRazorPages();
app.MapControllers();

app.Run();
