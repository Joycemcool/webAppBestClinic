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
        public PaymentViewModel Payment { get; set; } = new();

        public string shoppingCartValue = string.Empty;

        public string testJson = string.Empty;


        public void OnGet()
        {
            shoppingCartValue = Request.Cookies["ShoppingCart"];

            Payment.Products = shoppingCartValue;
        }

        public async Task<IActionResult> OnPostAsync()
        {


            using StringContent jsonPaymentData = new(System.Text.Json.JsonSerializer.Serialize(Payment));
            
            string apiurl = "https://nscc-inet2005-purchase-api.azurewebsites.net/purchase";

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Delete cookie
            Response.Cookies.Delete("ShoppingCart");


                // Read the content as a string
                testJson = await jsonPaymentData.ReadAsStringAsync();

            HttpResponseMessage response = await client.PostAsync(apiurl, jsonPaymentData);


            return Page(); 
            //return RedirectToPage("/Confirmation");

            
        }
    }
}

//return RedirectToPage("./Index");