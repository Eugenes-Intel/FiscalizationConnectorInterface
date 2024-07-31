using Rootsware.Fiscalization.Integration.FCI.Helpers;
using Rootsware.Fiscalization.Integration.FCI.Models.Global;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;
using Rootsware.Integration.SocketClient;
using Rootsware.Integration.SocketClient.Constants;
using Rootsware.Libraries.SocketCL.Constants;
using Rootsware.Libraries.SocketCL.Models;

namespace Rootsware.Fiscalization.Integration.FCI.Services;

/// <summary>
///     An
///     API
///     Connetor
///     Interfae.
///     The
///     component
///     that
///     mediates
///     communication
///     between
///     the
///     client
///     and
///     the
///     router
/// </summary>
internal abstract class ACI
{
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    protected readonly ISocketClient _socketClient;

    protected ACI(ISocketClient socketClient)
    {
        _socketClient = socketClient;
    }

    protected virtual async ValueTask<RequestResponse<TResponse>> TransactAsync<TResponse>(Message message, char socket = QChn.PND, byte sbit = Bit.GMS) where TResponse : class, IRequestResult
    {
        try
        {
            _semaphore.Wait();

            var response = await _socketClient.GetAsync(message, socket, sbit);

            //_socketClient.Shutdown();

            if (response?.Body is not { Contents: not null }) return new RequestResponse<TResponse> { IsSuccess = false, Message = Rscn.GHF13 }; // Todo: implement result pattern --> return Result.Success or Result.Error

            var result = await Serializer.GetDeserializedModelAsync<RequestResult<TResponse>>(response.Body.Contents) ?? new RequestResult<TResponse> { Trst = false, Message = Rscn.ISE17 };

            return new RequestResponse<TResponse> { IsSuccess = result.Trst, Message = result.Message, Value = result.Value };
        }
        catch (ObjectDisposedException)
        {
            return new RequestResponse<TResponse> { IsSuccess = false, Message = Rscn.SCE05 };
        }

        catch (Exception ex)
        {
            return new RequestResponse<TResponse> { IsSuccess = false, Message = ex.Message };
        }

        finally
        {
            _semaphore.Release(); /*_socketClient.Close();*/
        }
    }
}