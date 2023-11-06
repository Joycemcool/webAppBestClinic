using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorldBestClinic.Data;
using WorldBestClinic.Models;

namespace WorldBestClinic.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly WorldBestClinic.Data.WorldBestClinicContext _context;

        IWebHostEnvironment _env;

        [BindProperty]
        public Service Service { get; set; } = default!;

        [BindProperty]
        public IFormFile? ImageUpload { get; set; }

        public CreateModel(WorldBestClinicContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD



        public async Task<IActionResult> OnPostAsync()
        {
            //What userId = int.Parse do?

            // Make a unique image name
            string imageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-") + ImageUpload.FileName;

            Service.FileName = imageName;



            if (!ModelState.IsValid || _context.Service == null || Service == null)
            {
                return Page();
            }

            //
            // Upload the Image to the www/ServiceFolder folder
            //

            string file = _env.ContentRootPath + "\\wwwroot\\ServicePhotos\\" + imageName; //What's the best practice to name folder?

            using (FileStream fileStream = new FileStream(file, FileMode.Create))
            {
                ImageUpload.CopyTo(fileStream);
            }


            _context.Service.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
