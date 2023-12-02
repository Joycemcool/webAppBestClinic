using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldBestClinic.Data;
using WorldBestClinic.Models;

namespace WorldBestClinic.Pages.Services
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly WorldBestClinic.Data.WorldBestClinicContext _context;

        IWebHostEnvironment _env;

        [BindProperty]
        public Service Service { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageUpload { get; set; }

        public EditModel(WorldBestClinicContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service =  await _context.Service.FirstOrDefaultAsync(m => m.ServiceId == id);
            if (service == null)
            {
                return NotFound();
            }
            Service = service;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //
            // If upload new Service, Delete outdated Service picture
            //
            if (ImageUpload != null)
            {
                string outdatedFile = _env.ContentRootPath + "\\wwwroot\\ServicePhotos\\" + Service.FileName;
                if (System.IO.File.Exists(outdatedFile))
                {
                    System.IO.File.Delete(outdatedFile);
                }
                string? updatedImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-") + ImageUpload.FileName;

                //
                // Upload the Image to the www/ServicePhoto folder
                //
                Service.FileName = updatedImageName;

                string file = _env.ContentRootPath + "\\wwwroot\\ServicePhotos\\" + updatedImageName;

                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    ImageUpload.CopyTo(fileStream);
                }

            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            //
            //Attach updated Service
            //

            _context.Attach(Service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(Service.ServiceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiceExists(int id)
        {
          return (_context.Service?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
