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

        public Dictionary<int,int> itemsQuantity { get; set; }
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

                    //ServiceQuantities = new List<int>();
                    ServiceQuantities = new List<int>();
                    itemsQuantity = new Dictionary<int, int>();

                    foreach (var serviceId in serviceIds)
                    {
                        if (itemsQuantity.ContainsKey(serviceId))
                        {
                            // Increment count if serviceId already exists in the dictionary
                            itemsQuantity[serviceId]++;
                        }
                        else
                        {
                            // Add serviceId to the dictionary with count 1 if it doesn't exist
                            itemsQuantity[serviceId] = 1;
                        }
                    }

                    foreach (var serviceId in serviceIds)
                    {
                        // Use the dictionary to get the quantity for each serviceId
                        int quantity = itemsQuantity[serviceId];
                        ServiceQuantities.Add(quantity);
                    }

                    var numberGroups = 

                    //Subtotal = Services.Sum(s => s.Price);
                    Subtotal = Services.Select((s, index) => s.Price * ServiceQuantities[index]).Sum();
                }

                Tax =(float)( Subtotal * 0.15);

                Total = Subtotal + Tax + Delivery;
            }
               
        }
    }
}
