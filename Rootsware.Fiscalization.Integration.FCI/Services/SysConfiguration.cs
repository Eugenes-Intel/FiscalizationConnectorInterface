using System.Text;
using System.Text.Json;
using Rootsware.Fiscalization.Integration.FCI.Models.Requests;
using Rootsware.Fiscalization.Integration.FCI.Models.Results;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;
using Rootsware.Integration.SocketClient;
using Rootsware.Libraries.SocketCL.Constants;
using Rootsware.Libraries.SocketCL.Enums;
using Rootsware.Libraries.SocketCL.Models;

namespace Rootsware.Fiscalization.Integration.FCI.Services;

internal class SysConfiguration(ISocketClient socketClient) : ACI(socketClient), IDeviceConfig
{
    public async ValueTask<RequestResponse<SnResult>> GenerateSnAsync(SnRequest request)
    {
        var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.DSN, Sender = GetType().Name, Drive = request.Drive, Contents = contents };

        return await TransactAsync<SnResult>(message, sbit: Bit.TRM);
    }

    public async ValueTask<RequestResponse<RegdResult>> RegisterDeviceAsync(RegdRequest request)
    {
        var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.DRR, Sender = GetType().Name, Drive = request.Drive, Contents = contents };

        return await TransactAsync<RegdResult>(message, sbit: Bit.TRM);
    }
}