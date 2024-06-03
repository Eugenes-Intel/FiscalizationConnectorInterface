using FiCon.Models.Requests;
using FiCon.Models.Results;
using FiCon.Models.Shared;

namespace FiCon
{
    /// <summary>
    /// Transacting device manager. Manages the transactional aspect of a device in relation to transactions.
    /// </summary>
    public interface IDeviceConfig
    {
        ValueTask<RequestResponse<SnResult>> GenerateSnAsync(SnRequest request);
        ValueTask<RequestResponse<RegdResult>> RegisterDeviceAsync(RegdRequest request);
    }
}