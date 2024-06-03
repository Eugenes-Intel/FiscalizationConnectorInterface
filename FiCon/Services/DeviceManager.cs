using FiCon.Models.Components;
using SocketClient;

namespace FiCon.Services
{
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
}
