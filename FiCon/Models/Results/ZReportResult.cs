using FiCon.Models.Global;

namespace FiCon.Models.Results
{
    public class ZReportResult : IRequestResult
    {
        public char Drive { get; set; }

        public string OperationID { get; set; }

        public ushort DeviceId { get; set; }

        public string FiscalDayStatus { get; set; }

        public string Message { get; set; }
    }
}
