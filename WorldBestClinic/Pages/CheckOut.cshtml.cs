using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WorldBestClinic.ViewModels;
using System.Text.Json;

namespace WorldBestClinic.Pages
{
    public class CheckOutModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        [BindProperty]
        public PaymentViewModel Payment { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string shoppingCartValue = Request.Cookies["ShoppingCart"];

            Payment.products = shoppingCartValue;

            using StringContent jsonPaymentData = new(System.Text.Json.JsonSerializer.Serialize(Payment) );
            string apiurl = "https://nscc-inet2005-purchase-api.azurewebsites.net/purchase";

            HttpResponseMessage response = await client.PostAsync(apiurl, jsonPaymentData);

            return RedirectToPage("/Confirmation");

            
        }
    }
}
