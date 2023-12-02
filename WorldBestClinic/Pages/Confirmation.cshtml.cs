using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace WorldBestClinic.Pages
{
    public class ConfirmationModel : PageModel
    {
        public int StatusCode { get;set; }

        public void OnGet()
        {
            var statusCode = TempData["StatusCode"];
            if (statusCode != null && int.TryParse(statusCode.ToString(), out int parsedStatusCode))
            {
                StatusCode =parsedStatusCode;
            }
          
        }
    }
}
