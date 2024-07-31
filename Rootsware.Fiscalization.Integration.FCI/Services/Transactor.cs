using System.Text;
using System.Text.Json;
using Rootsware.Fiscalization.Integration.FCI.Models.Components;
using Rootsware.Fiscalization.Integration.FCI.Models.Results;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;
using Rootsware.Integration.SocketClient;
using Rootsware.Libraries.SocketCL.Constants;
using Rootsware.Libraries.SocketCL.Enums;
using Rootsware.Libraries.SocketCL.Models;

namespace Rootsware.Fiscalization.Integration.FCI.Services;

internal class Transactor(ISocketClient socketClient) : ACI(socketClient), ITransactor
{
    public async ValueTask<RequestResponse<TransactResult>> TransactAsync(Invoice request)
    {
        var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

        var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.XZV, Sender = GetType().Name, Drive = request.Drive, Contents = contents };

        return await TransactAsync<TransactResult>(message, sbit: Bit.TRM);
    }
}