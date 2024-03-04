using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace WorldBestClinic.Pages
{
    public class ConfirmationModel : PageModel
    {
        //public int StatusCode { get;set; }
        public string confirmationMsg;

        //public void OnGet(string responseContent)
        //{
        //    confirmationMsg = responseContent;
          
        //}
        public void OnGet()
        {
            Response.Cookies.Delete("ShoppingCart");
            confirmationMsg = "Thank you for your purchase";
            //confirmationMsg = responseContent;

        }
    }
}
