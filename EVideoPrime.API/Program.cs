using EVideoPrime.API.BusinessAccessLayer;
using EVideoPrime.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movies.API.DAL;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.
                        SetBasePath(builder.Environment.ContentRootPath).
                        AddJsonFile("ApiVersion.json", optional: false, reloadOnChange: true).Build();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRouting(option =>
{
    option.LowercaseUrls = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                        new HeaderApiVersionReader("x-api-version"),
                                                        new MediaTypeApiVersionReader("x-api-version"),
                                                        new QueryStringApiVersionReader("api-version"));
    options.ReportApiVersions = true;
});
builder.Services.AddSwaggerGen(option =>
{
    var versions = configuration.GetSection("ApiVersions").
            Get<List<ApiVersionDescriptor>>();
    foreach (var ver in versions)
    {
        option.SwaggerDoc(ver.Version, ver.ApiInfo);
    }
    option.DocInclusionPredicate((version, apiDescription) =>
    {
        if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
        {
            return false;
        }
        var versions = methodInfo.DeclaringType.GetConstructors().
                        SelectMany(constructorInfo => constructorInfo.DeclaringType.CustomAttributes.
                        Where(attributeData => attributeData.AttributeType == typeof(ApiVersionAttribute)).
                        SelectMany(attributeData => attributeData.ConstructorArguments.
                        Select(attributeTypedData => attributeTypedData.Value)));
        var result = versions.Any(v => string.Equals($"v{v}", version));
        return result;
    });
    option.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
    option.OperationFilter<ApiVersionFilter>();

});
builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("VideoPrimeDb")));
builder.Services.AddRepositories();
builder.Services.AddBusinessLayer();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(options =>
{
    string applicationBasePath = configuration["ApplicationBasePath"];
    string swaggerRouteTemplate = @"swagger/{documentName}/swagger.json";
    options.RouteTemplate = swaggerRouteTemplate;
    options.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Servers = new List<OpenApiServer>
                {
                    new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/{applicationBasePath}" }
                });
});
app.UseSwaggerUI(options =>
{
    var apiVersions = configuration.GetSection("ApiVersions").
     Get<List<ApiVersionDescriptor>>();
    string applicationBasePath = configuration["ApplicationBasePath"];
    foreach (var descriptor in apiVersions)
    {
        var endpoint = string.IsNullOrWhiteSpace(applicationBasePath) ? descriptor.EndPoint : $"/{applicationBasePath}{descriptor.EndPoint}";
        options.SwaggerEndpoint(endpoint, descriptor.Version);
    }
});
app.Use((context, next) => { 
    using (var scopes = app.Services.CreateScope())
    {
        var dbContext = app.Services.GetRequiredService<SqlDbContext>();
        if (dbContext.Database.EnsureCreated())
            dbContext.Database.Migrate();
    }
    return next(context); 
});
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();


public class ReplaceVersionWithExactValueInPathFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths;

        swaggerDoc.Paths = new OpenApiPaths();

        foreach (var path in paths)
        {
            var key = path.Key.Replace("v{version}", $"v{swaggerDoc.Info.Version}");

            var value = path.Value;

            swaggerDoc.Paths.Add(key, value);
        }
    }
}

public class ApiVersionFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var parametersToRemove = operation.Parameters.Where(x => x.Name == "version").ToList();
        foreach (var parameter in parametersToRemove)
            operation.Parameters.Remove(parameter);
    }
}