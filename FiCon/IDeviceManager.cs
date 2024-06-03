using FiCon.Models.Components;

namespace FiCon
{
    /// <summary>
    /// Transacting device manager. Manages the transactional aspect of a device in relation to transactions.
    /// </summary>
    public interface IDeviceManager
    {
        ValueTask<DeviceInfo> GetDeviceInfoAsync();
        ValueTask<DeviceStatus> GetDeviceStatusAsync();
    }
}