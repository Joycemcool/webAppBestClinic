using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldBestClinic.Data;
using WorldBestClinic.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorldBestClinic.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly WorldBestClinic.Data.WorldBestClinicContext _context;

        public string ShoppingCartMessage { get; set; } = string.Empty;

        public List<Service> Services { get; set; } = new();


        public ShoppingCartModel(WorldBestClinicContext context)
        {
            _context = context;

        }

        public async Task OnGetAsync()
        {
            if (_context.Service != null)
            {
                ShoppingCartMessage = Request.Cookies["ShoppingCart"];

                if (!string.IsNullOrEmpty(ShoppingCartMessage))
                {
                    // Split the comma-separated values and convert them to integers (assuming the values are integers)
                    var serviceIds = ShoppingCartMessage.Split(',').Select(int.Parse).ToList();

                    // Query the database to get services based on the IDs from the cookie
                    Services = await _context.Service.Where(s => serviceIds.Contains(s.ServiceId)).ToListAsync();
                }
            }
               
        }
    }
}
