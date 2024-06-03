using FiCon.Helpers;
using FiCon.Models.Queue;
using FiCon.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocketClient;

namespace FiCon.Configs
{
    public static class Services
    {
        public static void AddFiscalization(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<HostConfig>(configuration.GetSection(nameof(HostConfig)));
            services.AddSingleton((serviceProvider) => Helper.ScopeEntity<ISocketClient>());
            services.AddScoped<ITransactor, Transactor>();
            services.AddScoped<IDayManager, DayManager>();
            services.AddScoped<IDeviceManager, DeviceManager>();
            services.AddScoped<IDeviceConfig, SysConfiguration>();
        }
    }
}
