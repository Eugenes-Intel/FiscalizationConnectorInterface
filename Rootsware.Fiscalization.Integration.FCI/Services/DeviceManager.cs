using Rootsware.Fiscalization.Integration.FCI.Models.Components;
using Rootsware.Integration.SocketClient;

namespace Rootsware.Fiscalization.Integration.FCI.Services;

internal class DeviceManager : IDeviceManager
{
    private readonly ISocketClient _queueClient;

    public DeviceManager(ISocketClient queueClient)
    {
        _queueClient = queueClient;
    }

    public async ValueTask<DeviceInfo> GetDeviceInfoAsync()
    {
        await Task.Delay(1000);
        return new DeviceInfo();
    }

    public async ValueTask<DeviceStatus> GetDeviceStatusAsync()
    {
        await Task.Delay(1000);
        return new DeviceStatus();
    }
}