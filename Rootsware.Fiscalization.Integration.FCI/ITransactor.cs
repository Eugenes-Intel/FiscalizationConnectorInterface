using Rootsware.Fiscalization.Integration.FCI.Models.Components;
using Rootsware.Fiscalization.Integration.FCI.Models.Results;
using Rootsware.Fiscalization.Integration.FCI.Models.Shared;

namespace Rootsware.Fiscalization.Integration.FCI;

public interface ITransactor
{
    ValueTask<RequestResponse<TransactResult>> TransactAsync(Invoice invoice);
}