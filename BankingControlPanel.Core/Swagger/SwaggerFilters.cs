using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BankingControlPanel.Core.Swagger
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type.IsEnum
                || (Nullable.GetUnderlyingType(context.Type)?.IsEnum is true))
            {
                var values = new List<string>();
                var type = context.Type.IsEnum ? context.Type : Nullable.GetUnderlyingType(context.Type);
                foreach (var value in Enum.GetValues(type))
                {
                    values.Add("<li><i>" + (int)value + "</i> = " + Enum.GetName(type, value) + "</li>");
                }
                var description = "<ul>" + string.Join("", values) + "</ul>";
                model.Description = description;
            }

            var descriptons = context.MemberInfo?.GetCustomAttributesData()
                    .Where(a => a.AttributeType.Name == "DescriptionAttribute")
                    .Where(a => a.ConstructorArguments.Any())
                    .Select(a => a.ConstructorArguments.First().Value)
                    .ToList();
            if (descriptons is not null && descriptons.Any())
            {
                descriptons.ForEach(d => {
                    model.Description += d;
                });
            }
        }
    }

    public class ParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (!string.IsNullOrEmpty(parameter?.Schema?.Description))
            {
                parameter.Description += parameter.Schema.Description;
            }
        }
    }
}
