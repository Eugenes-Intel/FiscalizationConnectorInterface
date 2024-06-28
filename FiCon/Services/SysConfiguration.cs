using FiCon.Models.Requests;
using FiCon.Models.Results;
using FiCon.Models.Shared;
using SocketCL.Constants;
using SocketCL.Enums;
using SocketCL.Models;
using SocketClient;
using System.Text;
using System.Text.Json;

namespace FiCon.Services
{
    internal class SysConfiguration(ISocketClient socketClient) : ACI(socketClient), IDeviceConfig
    {
        public async ValueTask<RequestResponse<SnResult>> GenerateSnAsync(SnRequest request)
        {
            var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

            var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.DSN, Sender = this.GetType().Name, Drive = request.Drive, Contents = contents };

            return await TransactAsync<SnResult>(message, sbit: Bit.TRM);
        }

        public async ValueTask<RequestResponse<RegdResult>> RegisterDeviceAsync(RegdRequest request)
        {
            var contents = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));

            var message = new Message { MGrp = MGrp.IDN, MTyp = MTyp.drc, Module = Mdl.ACI, Itxn = Bit.DRR, Sender = this.GetType().Name, Drive = request.Drive, Contents = contents };

            return await TransactAsync<RegdResult>(message, sbit: Bit.TRM);
        }
    }
}
