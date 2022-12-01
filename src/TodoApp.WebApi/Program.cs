using Agoda.IoC.NetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.Extensions;
using TodoApp.Core.Configs;
using TodoApp.WebApi.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo{Title = "Todo App",Version = "V1"});
    c.AddAutoRestCompatible();
    c.UseInlineDefinitionsForEnums();
    c.MakeValueTypePropertiesRequired();
    c.DefineOperationIdFromControllerNameAndActionName();
    c.EnableAnnotations();
    c.SchemaFilter<RequiredNotNullableSchemaFilter>();
});

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
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();