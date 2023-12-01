using System;
using System.ComponentModel;
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

        [DisplayName("Credit Card Number")]
        [CreditCard] public string CCNumber { get; set; } = string.Empty;

        [DisplayName("Credit Card Expiration Date")]
        //[RegularExpression(@"^(0[1-9]|1[0-2])((0?[1-9]|[1-9][0-9])$"), StringLength(5)]
        [Required]
        public string CCExpiryDate { get; set; } = string.Empty;

        [DisplayName("CVV Number")]
        [RegularExpression(@"^[0-9]{3,4}$"), StringLength(3)]
        public string Cvv { get; set; } =string.Empty;

        public string Products { get; set; } = string.Empty;

    }
}


//https://learn.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/validating-user-input-in-aspnet-web-pages-sites
//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation?view=aspnetcore-8.0