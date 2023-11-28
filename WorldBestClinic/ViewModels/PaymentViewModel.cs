using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldBestClinic.ViewModels
{
    public class PaymentViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Province { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public int CCNumber { get; set; } = 0;

        [RegularExpression(@"^[0-9]{3,4}$"), StringLength(4)]

        [Required]
        public string CCExpiryDate { get; set; } = string.Empty;

        
        public int Cvv { get; set; } = 0;

        public string products { get; set; } = string.Empty;

    }
}


//https://learn.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/validating-user-input-in-aspnet-web-pages-sites
//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation?view=aspnetcore-8.0