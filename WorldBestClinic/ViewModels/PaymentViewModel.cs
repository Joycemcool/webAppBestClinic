namespace WorldBestClinic.ViewModels
{
    public class PaymentViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Province { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
        public int CCNumber { get; set; } = 0;
        public string CCExpiryDate { get; set; } = string.Empty;

        public int Cvv { get; set; } = 0;

        public string products { get; set; } = string.Empty;

    }
}
