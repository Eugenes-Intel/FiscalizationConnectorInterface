using FiCon.Helpers;
using FiCon.Models.Global;
using FiCon.Models.Shared;
using SocketCL.Constants;
using SocketCL.Models;
using SocketClient.Constants;
using SocketClient;


namespace FiCon.Services
{
    /// <summary>
    /// An API Connetor Interfae. The component that mediates communication between the client and the router
    /// </summary>
    internal abstract class ACI
    {
        protected readonly ISocketClient _socketClient;

        protected ACI(ISocketClient socketClient) => _socketClient = socketClient;

        protected virtual async ValueTask<RequestResponse<TResponse>> TransactAsync<TResponse>(Message message, char socket = QChn.PND, byte sbit = Bit.GMS) where TResponse : class, IRequestResult
        {
            try
            {
                var response = await _socketClient.GetAsync(message, socket, sbit);

                await _socketClient.ReleaseAsync();

                if (response is not null && response.Body is not null && response.Body.Contents is not null)
                {
                    var result = await Serializer.GetDeserializedModelAsync<RequestResult<TResponse>>(response.Body.Contents) ?? new RequestResult<TResponse> { Trst = false, Message = Rscn.ISE17 };

                    return new RequestResponse<TResponse> { IsSuccess = result.Trst, Message = result.Message, Value = result.Value };
                }
                return new RequestResponse<TResponse> { IsSuccess = false, Message = Rscn.GHF13 }; // Todo: implement result pattern --> return Result.Success or Result.Error
            }
            catch (ObjectDisposedException) { return new RequestResponse<TResponse>() { IsSuccess = false, Message = Rscn.SCE05 }; }

            catch (Exception ex) { return new RequestResponse<TResponse>() { IsSuccess = false, Message = ex.Message }; }
        }
    }
}