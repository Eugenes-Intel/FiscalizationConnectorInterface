using Rootsware.Fiscalization.Integration.FCI.Models.Requests;
using Rootsware.Fiscalization.Integration.FCI.Models.Results;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;

namespace Rootsware.Fiscalization.Integration.FCI;

/// <summary>
///     Transacting
///     device
///     manager.
///     Manages
///     the
///     transactional
///     aspect
///     of
///     a
///     device
///     in
///     relation
///     to
///     transactions.
/// </summary>
public interface IDeviceConfig
{
    ValueTask<RequestResponse<SnResult>> GenerateSnAsync(SnRequest request);
    ValueTask<RequestResponse<RegdResult>> RegisterDeviceAsync(RegdRequest request);
}