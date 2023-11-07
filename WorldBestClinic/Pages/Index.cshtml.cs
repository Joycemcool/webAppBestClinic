using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldBestClinic.Data;
using WorldBestClinic.Models;

namespace WorldBestClinic.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly WorldBestClinicContext _context;

        public IList<Service> Services { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, WorldBestClinicContext context)
        {
            _logger = logger;
            _context = context;

        }

        public void OnGet()
        {
            if (_context != null)
            {
                Services = _context.Service.OrderByDescending(d => d.ServiceId).ToList();
            }
        }
    }
}