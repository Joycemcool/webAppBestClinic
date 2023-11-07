using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WorldBestClinic.Data;
using WorldBestClinic.Models;

namespace WorldBestClinic.Pages.Services
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WorldBestClinic.Data.WorldBestClinicContext _context;

        public IndexModel(WorldBestClinic.Data.WorldBestClinicContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Service != null)
            {
                Service = await _context.Service.ToListAsync();
            }
        }
    }
}
