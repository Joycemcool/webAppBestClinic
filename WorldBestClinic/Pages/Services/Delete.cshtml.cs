﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorldBestClinic.Data;
using WorldBestClinic.Models;

namespace WorldBestClinic.Pages.Services
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly WorldBestClinic.Data.WorldBestClinicContext _context;

        public DeleteModel(WorldBestClinic.Data.WorldBestClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);

            if (service == null)
            {
                return NotFound();
            }
            else 
            {
                Service = service;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }
            var service = await _context.Service.FindAsync(id);

            if (service != null)
            {
                Service = service;
                _context.Service.Remove(Service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
