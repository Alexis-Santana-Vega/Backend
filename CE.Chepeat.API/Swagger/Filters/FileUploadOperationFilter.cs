using Swashbuckle.AspNetCore.SwaggerGen;

namespace CE.Chepeat.API.Swagger.Filters
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.MethodInfo.GetParameters()
                .Where(p => p.ParameterType == typeof(IFormFile));

            foreach (var param in fileParams)
            {
                operation.Parameters.Remove(operation.Parameters.FirstOrDefault(p => p.Name == param.Name));
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties =
                            {
                                [param.Name] = new OpenApiSchema
                                {
                                    Type = "string",
                                    Format = "binary"
                                }
                            },
                                Required = new HashSet<string> { param.Name }
                            }
                        }
                    }
                };
            }
        }
    }
}
