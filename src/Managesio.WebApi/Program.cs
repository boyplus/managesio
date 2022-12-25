using Agoda.IoC.NetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.Extensions;
using Managesio.Core.Configs;
using Managesio.Core.MapperProfiles;
using Managesio.Core.Middlewares;
using Managesio.WebApi.Configs;
using Managesio.WebApi.Startup;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json", true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperProfile));
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{Title = "Managesio App",Version = "V1"});
    c.AddAutoRestCompatible();
    c.UseInlineDefinitionsForEnums();
    c.MakeValueTypePropertiesRequired();
    c.DefineOperationIdFromControllerNameAndActionName();
    c.EnableAnnotations();
    c.SchemaFilter<RequiredNotNullableSchemaFilter>();
});

var secrets = configuration.GetSection(nameof(Secrets)).Get<Secrets>();
builder.Services.Configure<Secrets>(configuration.GetSection(nameof(Secrets)));
builder.Services.AddPostgresDbConnection(secrets);

builder.Services.AutoWireAssembly(new[] { typeof(AssemblyInfo).Assembly },false);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();