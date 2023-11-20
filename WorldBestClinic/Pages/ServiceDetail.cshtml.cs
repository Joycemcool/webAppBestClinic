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


        [BindProperty(SupportsGet = true)]
        public int ServiceId { get; set; }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public ServiceDetailModel(WorldBestClinicContext context, IWebHostEnvironment env)
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
    }
}
