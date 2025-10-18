
public static class OpenApiExtensions
{
    public static WebApplication UseOpenApi(this WebApplication app)
    {
        app.MapOpenApi();
        app.UseSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
                options.RoutePrefix = string.Empty; // Set Swagger UI at app's root
            }
        );
        return app;
    }
}
