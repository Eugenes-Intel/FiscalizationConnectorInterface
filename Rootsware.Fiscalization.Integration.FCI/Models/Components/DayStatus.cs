using Rootsware.Fiscalization.Integration.FCI.Models.Global;

namespace Rootsware.Fiscalization.Integration.FCI.Models.Components;

public class DayStatus : IRequestResult
{
    public string OperationID { get; set; }

    public string FiscalDayStatus { get; set; }

    public string FiscalDayReconciliationMode { get; set; }

    public DateTime FiscalDayClosed { get; set; }

    public string FiscalDayClosingErrorCode { get; set; }

    public uint LastReceiptGlobalNo { get; set; }

    public uint LastFiscalDayNo { get; set; }
    public ushort DeviceId { get; set; }
}