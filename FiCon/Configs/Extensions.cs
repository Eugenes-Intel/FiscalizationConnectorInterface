using FiCon.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FiCon.Configs
{
    public static class Extensions
    {
        public static void UseFiscalization(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Fiscalization>();
        }
    }
}
