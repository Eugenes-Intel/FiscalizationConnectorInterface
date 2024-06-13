using FiCon.Models.Components;
using FiCon.Models.Requests;
using FiCon.Models.Results;
using FiCon.Models.Shared;

namespace FiCon
{
    public interface IDayManager
    {
        ValueTask<RequestResponse<DycgResult>> DConfigAsync(DmgrRequest request);
        
        ValueTask<RequestResponse<DayStatus>> DStatusAsync(DmgrRequest request);

        ValueTask<RequestResponse<ZReportResult>> DSwitchAsync(DmgrRequest request);
    }
}