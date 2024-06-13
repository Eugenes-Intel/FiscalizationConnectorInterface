using FiCon.Models.Global;

namespace FiCon.Models.Results
{
    /// <summary>
    /// A result model for fiscal day configuration process
    /// </summary>
    public class DycgResult : IRequestResult
    {
        public string OperationID { get; set; }
        public string TaxPayerName { get; set; }
        public string TaxPayerTIN { get; set; }
        public string VatNumber { get; set; }
        public string DeviceSerialNo { get; set; }
        public string DeviceBranchName { get; set; }
        public Addr DeviceBranchAddress { get; set; }
        public Ctct DeviceBranchContacts { get; set; }
        public string DeviceOperatingMode { get; set; }
        public int TaxPayerDayMaxHrs { get; set; }
        public Aptx[] ApplicableTaxes { get; set; }
        public DateTime CertificateValidTill { get; set; }
        public string QrUrl { get; set; }
        public int TaxpayerDayEndNotificationHrs { get; set; }
        public ushort DeviceId { get; set; }
    }

    public class Addr
    {
        public string Province { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
    }

    public class Ctct
    {
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }

    public class Aptx
    {
        public double TaxPercent { get; set; }
        public string TaxName { get; set; }
    }
}