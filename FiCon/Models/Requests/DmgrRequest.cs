namespace FiCon.Models.Requests
{
    /// <summary>
    /// A model for day management requests.
    /// </summary>
    public class DmgrRequest
    {
        public char Drive { get; set; }

        public ushort DeviceId { get; set; }
    }
}
