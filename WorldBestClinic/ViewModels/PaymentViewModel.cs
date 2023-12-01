using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WorldBestClinic.ViewModels
{
    public class PaymentViewModel
    {

        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public string address { get; set; } = string.Empty;

        [Required]
        public string city { get; set; } = string.Empty;

        [Required]
        public string province { get; set; } = string.Empty;

        [Required]
        public string postalCode { get; set; } = string.Empty;

        [Required]
        public string country { get; set; } = string.Empty;

        [DisplayName("Credit Card Number")]
        [JsonIgnore]
        [CreditCard] public string CCNumberString { get; set; }

        //get the string input and change to int
        public long ccNumber { get; set; }

        [DisplayName("Credit Card Expiration Date")]
        [RegularExpression(@"^(0[1-9]|1[0-2])([0-9]{2})$", ErrorMessage = "Invalid format")]
        [StringLength(4, ErrorMessage = "Invalid length")]
        [Required]
        public string ccExpiryDate { get; set; } = string.Empty;

        [DisplayName("CVV Number")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid format")]
        [StringLength(4, ErrorMessage = "Invalid length")]
        [JsonIgnore]
        public string cvvString { get; set; } =string.Empty;

        //get the string input and change to ints
        public int cvv { get; set; }

        [Required]
        public string products { get; set; } = string.Empty;

    }
}


//https://learn.microsoft.com/en-us/aspnet/web-pages/overview/ui-layouts-and-themes/validating-user-input-in-aspnet-web-pages-sites
//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/validation?view=aspnetcore-8.0