using FiCon.Models.Components;
using FiCon.Models.Requests;
using FiCon.Models.Results;
using FiCon.Models.Shared;

namespace FiCon
{
    public interface IDayManager
    {
        ValueTask<DayInfo> GetDayInfoAsync();

        ValueTask<RequestResponse<DayStatus>> DStatusAsync(DmgrRequest request);

        ValueTask<RequestResponse<ZReportResult>> DSwitchAsync(DmgrRequest request);
    }
}