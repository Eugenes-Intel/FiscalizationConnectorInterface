using Microsoft.AspNetCore.Builder;

namespace Rootsware.Fiscalization.Integration.FCI.Configs;

public static class Extensions
{
    public static void UseFiscalization(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<Middleware.Fiscalization>();
    }
}