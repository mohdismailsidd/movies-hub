using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ApiVersionDescriptor
{
    public string Version { get; set; }
    public OpenApiInfo ApiInfo { get; set; }
    public string EndPoint { get; set; }
}