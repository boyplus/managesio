using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Managesio.WebApi.Configs;

public class RequiredNotNullableSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context) {
        if (schema.Properties == null) {
            return;
        }

        var requiredButNullableProperties = schema
            .Properties
            .Where(x => x.Value.Nullable && schema.Required.Contains(x.Key))
            .ToList();

        foreach (var property in requiredButNullableProperties) {
            property.Value.Nullable = false;
        }

        var notRequiredProperties = schema
            .Properties
            .Where(x => !schema.Required.Contains(x.Key))
            .ToList();

        foreach (var property in notRequiredProperties) {
            property.Value.Nullable = false;
        }
    }

}