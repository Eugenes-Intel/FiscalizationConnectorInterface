using FiCon.Models.Components;
using FiCon.Models.Requests;
using FiCon.Models.Results;
using FiCon.Models.Shared;
using SocketClient;
using SocketCL.Constants;
using SocketCL.Enums;
using SocketCL.Models;
using System.Text;
using System.Text.Json;

namespace FiCon.Services
{
    internal class DayManager(ISocketClient socketClient) : ACI(socketClient), IDayManager
    {
        public async ValueTask<ZReportResult> ZReportAsync(DmgrRequest report)
        {
            await Task.Delay(1000);
            return new ZReportResult();
        }

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
    }
}
