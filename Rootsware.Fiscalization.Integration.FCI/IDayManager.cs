using Rootsware.Fiscalization.Integration.FCI.Models.Components;
using Rootsware.Fiscalization.Integration.FCI.Models.Requests;
using Rootsware.Fiscalization.Integration.FCI.Models.Results;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;

namespace Rootsware.Fiscalization.Integration.FCI;

public interface IDayManager
{
    ValueTask<RequestResponse<DycgResult>> DConfigAsync(DmgrRequest request);

    ValueTask<RequestResponse<DayStatus>> DStatusAsync(DmgrRequest request);

    ValueTask<RequestResponse<ZReportResult>> DSwitchAsync(DmgrRequest request);
}