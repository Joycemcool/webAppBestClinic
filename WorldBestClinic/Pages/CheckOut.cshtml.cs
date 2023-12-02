using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WorldBestClinic.ViewModels;
using System.Text.Json;
using System.Net;
using System.Numerics;

namespace WorldBestClinic.Pages
{
    public class CheckOutModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        [BindProperty]
        public PaymentViewModel Payment { get; set; } = new();

        public string shoppingCartValue = string.Empty;


        public void OnGet()
        {
            shoppingCartValue = Request.Cookies["ShoppingCart"];

            Payment.products = shoppingCartValue;
        }

        public async Task<IActionResult> OnPostAsync()
        {

           string cleanedCCNumber = Payment.CCNumberString.Replace(" ", "");
            string cleanedCvvNumber = Payment.cvvString;
            long ccNumber = long.Parse(cleanedCCNumber);
            Payment.ccNumber = ccNumber;
            Payment.cvv = Int32.Parse(cleanedCvvNumber);


            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Delete cookie
            string jsonString = System.Text.Json.JsonSerializer.Serialize(Payment);

            string apiurl = "https://nscc-inet2005-purchase-api.azurewebsites.net/purchase";


            // Read the content as a string
            //testJson = await jsonPaymentData.ReadAsStringAsync();

            StringContent content =new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiurl, content);

            if (response.IsSuccessStatusCode)
            {
                var statusCode = (int)response.StatusCode;
                Response.Cookies.Delete("ShoppingCart");

                //Store the statusCode in TempData

                TempData["StatusCode"] = statusCode;

                return RedirectToPage("/Confirmation");
            }
            else
            {
                // Request failed with an error (status code is not 2xx)
                // You might want to handle specific status codes or log the error
                HttpStatusCode statusCode = response.StatusCode;

                // Example: Check for a specific status code
                if (statusCode == HttpStatusCode.NotFound)
                {

                }

                // Example: Log the error
                Console.WriteLine($"Error: {statusCode} - {response.ReasonPhrase}");

                return Page();
            }
            
        }
    }
}

//return RedirectToPage("./Index");