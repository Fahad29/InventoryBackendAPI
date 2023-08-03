using IMS;
using IMS.Api.Common.Helper;
using IMS.Api.Common.Model.CommonModel;
using IMS.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddEnvironmentVariables()
       .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextCore>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings")["DefaultConnection"]));

builder.Services.AddRepositories();


builder.Services.AddApiVersioning(
           options =>
           {

               options.ReportApiVersions = true;
               options.DefaultApiVersion = new ApiVersion(1, 0);
               options.AssumeDefaultVersionWhenUnspecified = true;
           });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var fileName = Environment.GetEnvironmentVariable("HOSTNAME") ?? "add-on" + "_";

string f = Path.Combine(Environment.CurrentDirectory, $@"Content\Logs\log-{fileName}.txt");

Log.Logger = (Serilog.ILogger)new LoggerConfiguration()
    .WriteTo.File(f, rollingInterval: RollingInterval.Day)
      .MinimumLevel.Debug()
     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
   .MinimumLevel.Override("Quartz", LogEventLevel.Warning)
    .Enrich.FromLogContext()
     .CreateLogger();

APIConfig.Log = Log.Logger;

app.Run();

builder.Services.AddSingleton(configuration);


builder.Services.AddDbContext<ContextCore>(options => options.UseSqlServer(APIConfig.Configuration?.GetSection("ConnectionStrings")["DefaultConnection"]));


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()

            );
});

builder.Services.AddMvc()
 .AddNewtonsoftJson(options =>
 {
     options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
     options.SerializerSettings.ContractResolver = new LowercaseContractResolver();
 });

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.APIKeyBuilder();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


