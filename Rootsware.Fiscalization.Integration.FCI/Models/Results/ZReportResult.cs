using Rootsware.Fiscalization.Integration.FCI.Models.Global;

namespace Rootsware.Fiscalization.Integration.FCI.Models.Results;

public class ZReportResult : IRequestResult
{
    public char Drive { get; set; }

    public string OperationID { get; set; }

    public string FiscalDayStatus { get; set; }

    public string Message { get; set; }

    public ushort DeviceId { get; set; }
}