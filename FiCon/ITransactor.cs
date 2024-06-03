using FiCon.Models.Components;
using FiCon.Models.Results;
using FiCon.Models.Shared;

namespace FiCon
{
    public interface ITransactor
    {
        ValueTask<RequestResponse<TransactResult>> TransactAsync(Invoice invoice);
    }
}