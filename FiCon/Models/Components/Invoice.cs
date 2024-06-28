namespace FiCon.Models.Components
{
    public class Invoice
    {
        public char Drive { get; set; }

        public string Currency { get; set; }

        public string Country { get; set; }

        public string BranchName { get; set; }

        public string InvoiceNumber { get; set; }

        public string CustomerName { get; set; }

        public string CustomerVatNumber { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerTelephoneNumber { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerBpn { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal InvoiceTaxAmount { get; set; }

        public string InvoiceFlag { get; set; }

        public string Cashier { get; set; }

        public string? Reference { get; set; }

        public string InvoiceComment { get; set; }

        public string Items { get; set; }

        public string Currencies { get; set; }
    }
}
