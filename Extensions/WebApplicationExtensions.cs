using Microsoft.AspNetCore.Builder;

namespace gitactionswithdemo.api.Extensions;

public static class WebApplicationExtensions
{
    /// <summary>
    /// Configure environment-specific middleware (production safety features).
    /// This keeps Program.cs lean and centralizes the logic for reuse.
    /// </summary>
    public static WebApplication UseEnvironmentConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                    options.RoutePrefix = string.Empty; // Set Swagger UI at app's root
                }
            );
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        return app;
    }
}
