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

        //    public async Task<IActionResult> OnPostAsync(PaymentViewModel payment)        
        //    {
        //        string ShoppingCartMessage = Request.Cookies["ShoppingCart"];

        //        Payment = new PaymentViewModel();
        //        Payment.products = ShoppingCartMessage;

        //        string jsonPaymentData = System.Text.Json.JsonSerializer.Serialize<PaymentViewModel>(payment);
        //        string apiUrl = "https://nscc-inet2005-purchase-api.azurewebsites.net/purchase ";

        //        HttpResponseMessage response = await client.GetAsync(apiUrl, jsonPaymentData);

        //        RedirectToPage("/CheckOUt");
        //    }
    }
}
