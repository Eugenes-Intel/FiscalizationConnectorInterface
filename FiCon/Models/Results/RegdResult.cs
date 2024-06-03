using FiCon.Models.Global;

namespace FiCon.Models.Results
{
    /// <summary>
    /// A result model for device registration process
    /// </summary>
    public class RegdResult : IRequestResult
    {
        public char Drive { get; set; }

        public ushort DeviceId { get; set; }

        public string OperationId { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Signed certificate issued by the authority
        /// </summary>
        public string Certificate { get; set; }
    }
}