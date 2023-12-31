using IMS;
using IMS.Api.Common.Helper;
using IMS.Api.Common.Model.CommonModel;
using IMS.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(
    x =>
    {
        x.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
            {
                ProcessDictionaryKeys = true
            }
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMS API", Version = "v1" });

    // Configure JWT token authentication
    c.AddSecurityDefinition("jwt", new OpenApiSecurityScheme
    {
        Description = @"Authorization header using the Bearer scheme. 
                      Enter your token in the text input below.,
                      Example: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "jwt" // Reference the "jwt" security scheme defined above
                        }
                    },
                    new string[] { }
                }
            });
});

APIConfig.ContentRootPath = builder.Environment.ContentRootPath;

var configuration = new ConfigurationBuilder()
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddEnvironmentVariables()
       .Build();

builder.Services.AddRepositories();
// Register Exception Middleware

builder.Services.AddApiVersioning(
           options =>
           {

               options.ReportApiVersions = true;
               options.DefaultApiVersion = new ApiVersion(1, 0);
               options.AssumeDefaultVersionWhenUnspecified = true;

           });

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



var app = builder.Build();

app.UseCors("CorsPolicy");
//app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

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
APIConfig.Configuration = configuration;
//var logger = app.Services.GetRequiredService<ILoggerManager>();

app.APIKeyBuilder();
//app.ConfigureExceptionHandler(logger);
//app.ConfigureCustomExceptionMiddleware();
app.Run();


