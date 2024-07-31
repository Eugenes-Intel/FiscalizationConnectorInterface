using Rootsware.Fiscalization.Integration.FCI.Models.Global;

namespace Rootsware.Fiscalization.Integration.FCI.Models.Results;

public class TransactResult : IRequestResult
{
    public string Vcode { get; set; }

    public string Qcode { get; set; }

    public string Message { get; set; }

    public uint FiscalDay { get; set; }

    public uint ReceiptGlobalNo { get; set; }

    public uint ReceiptCounter { get; set; }

    public string Invoice { get; set; }
    public ushort DeviceId { get; set; }
}