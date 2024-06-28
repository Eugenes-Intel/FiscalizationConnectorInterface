using FiCon.Models.Components;
using FiCon.Models.Results;
using FiCon.Models.Shared;
using SocketCL.Constants;
using SocketCL.Enums;
using SocketCL.Models;
using SocketClient;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;

namespace FiCon.Services
{
    internal class Transactor(ISocketClient socketClient) : ACI(socketClient), ITransactor
    {
        public async ValueTask<RequestResponse<TransactResult>> TransactAsync(Invoice request)
        {
            var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

            var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.XZV, Sender = this.GetType().Name, Drive = request.Drive, Contents = contents };

            return await TransactAsync<TransactResult>(message, sbit: Bit.TRM);
        }
    }
}
