using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace BP.Api.Extensions
{
    public static class HealtCheckConfigureExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
                {
                    ResponseWriter = async (context, report) =>
                    {
                        await context.Response.WriteAsync("OK");
                    }
                }
            );
            return app;
        }
    }
}
