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

        public int ShoppingCartNums;

        public List<Service> Services { get; set; } = new();

        public float Subtotal = 0;

        public float Tax = 0;

        public float Delivery = 10;

        public float Total = 0;

        public List<int> ServiceQuantities { get; set; }

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
                    ShoppingCartNums = serviceIds.Count;

                    // Query the database to get services based on the IDs from the cookie
                    Services = await _context.Service.Where(s => serviceIds.Contains(s.ServiceId)).ToListAsync();

                    ServiceQuantities = new List<int>();
                    foreach (var serviceId in serviceIds)
                    {
                        int quantity = serviceIds.Count(id => id == serviceId);
                        ServiceQuantities.Add(quantity);
                    }

                    //Subtotal = Services.Sum(s => s.Price);
                    Subtotal = Services.Select((s, index) => s.Price * ServiceQuantities[index]).Sum();
                }

                Tax =(float)( Subtotal * 0.15);

                Total = Subtotal + Tax + Delivery;
            }
               
        }
    }
}
