using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rootsware.Fiscalization.Integration.FCI.Helpers;
using Rootsware.Fiscalization.Integration.FCI.Models.Queue;
using Rootsware.Fiscalization.Integration.FCI.Services;
using Rootsware.Integration.SocketClient;

namespace Rootsware.Fiscalization.Integration.FCI.Configs;

public static class Services
{
    public static void AddFiscalization(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<HostConfig>(configuration.GetSection(nameof(HostConfig)));
        services.AddSingleton(serviceProvider => Helper.ScopeEntity<ISocketClient>());
        services.AddScoped<ITransactor, Transactor>();
        services.AddScoped<IDayManager, DayManager>();
        services.AddScoped<IDeviceManager, DeviceManager>();
        services.AddScoped<IDeviceConfig, SysConfiguration>();
    }
}