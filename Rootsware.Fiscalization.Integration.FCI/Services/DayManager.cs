using System.Text;
using System.Text.Json;
using Rootsware.Fiscalization.Integration.FCI.Models.Components;
using Rootsware.Fiscalization.Integration.FCI.Models.Requests;
using Rootsware.Fiscalization.Integration.FCI.Models.Results;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;
using Rootsware.Integration.SocketClient;
using Rootsware.Libraries.SocketCL.Constants;
using Rootsware.Libraries.SocketCL.Enums;
using Rootsware.Libraries.SocketCL.Models;

namespace Rootsware.Fiscalization.Integration.FCI.Services;

internal class DayManager(ISocketClient socketClient) : ACI(socketClient), IDayManager
{
    public async ValueTask<RequestResponse<DycgResult>> DConfigAsync(DmgrRequest request)
    {
        var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = 0x028, Sender = GetType().Name, Drive = request.Drive, Contents = contents };

        return await TransactAsync<DycgResult>(message, sbit: Bit.TRM);
    }

    public async ValueTask<RequestResponse<ZReportResult>> DSwitchAsync(DmgrRequest request)
    {
        var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.DSR, Sender = GetType().Name, Drive = request.Drive, Contents = contents };

        return await TransactAsync<ZReportResult>(message, sbit: Bit.TRM);
    }

    public async ValueTask<RequestResponse<DayStatus>> DStatusAsync(DmgrRequest request)
    {
        var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.FST, Sender = GetType().Name, Drive = request.Drive, Contents = contents };

        return await TransactAsync<DayStatus>(message, sbit: Bit.TRM);
    }

    public async ValueTask<ZReportResult> ZReportAsync(DmgrRequest report)
    {
        await Task.Delay(1000);
        return new ZReportResult();
    }
}