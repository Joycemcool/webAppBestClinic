using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorldBestClinic.Data;
using WorldBestClinic.Models;

namespace WorldBestClinic
{
    public class ServiceDetailModel : PageModel
    {
        private readonly WorldBestClinic.Data.WorldBestClinicContext _context;

        [BindProperty]
        public Service Service { get; set; } = new();

        public string Message { get; set; } = string.Empty;

        public string MessageCookie { get; set; } = string.Empty;

        public ServiceDetailModel(WorldBestClinicContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            
            var service = _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);

            if (service == null)
            {
                return NotFound();
            }
            Service = await service;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
         //public async Task<IActionResult> OnPostAsync(int id)
        {
            //var service = _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);

            //if (service == null)
            //{
            //    return NotFound();
            //}
            //Service = await service;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            string oldCartValue = Request.Cookies["ShoppingCart"];

            // Set the "ShoppingCart" cookie with a 1-day expiry and a sliding expiration in 5 days.
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };


            //Add cookie 
            if (string.IsNullOrEmpty(oldCartValue))
            {
                Response.Cookies.Append("ShoppingCart", Service.ServiceId.ToString());
                
            }
            else
            {
                string newCartValue = oldCartValue + "," + Service.ServiceId.ToString();
                Response.Cookies.Append("ShoppingCart", newCartValue);

            }

            Message = "Service added to cart";

            MessageCookie = "Your shopping cart items: ;" + Request.Cookies["ShoppingCart"];

            await _context.SaveChangesAsync();  

            return RedirectToPage("/Index");

        }
    }
}
