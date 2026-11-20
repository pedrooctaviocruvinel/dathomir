using Microsoft.OpenApi;

namespace Dathomir.Backoffice.Presentation.Configurations;

internal static class SwaggerConfiguration
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration) =>
        services.AddSwaggerGen(sgo => sgo.SwaggerDoc("v1", BuildOpenApiInfo(configuration)));

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(suo => suo.SwaggerEndpoint("/swagger/v1/swagger.json", "Backoffice-chan"));
    }

    private static OpenApiInfo BuildOpenApiInfo(IConfiguration configuration) =>
        new()
        {
            Title = configuration["Swagger:Title"],
            Version = configuration["Swagger:Version"],
            Description = configuration["Swagger:Description"],
            Contact = new OpenApiContact
            {
                Name = configuration["Swagger:Contact:Name"],
                Email = configuration["Swagger:Contact:Email"],
                Url = new Uri(configuration["Swagger:Contact:Url"]!)
            },
            License = new OpenApiLicense
            {
                Name = configuration["Swagger:License:Name"],
                Url = new Uri(configuration["Swagger:License:Url"]!)
            }
        };
}
