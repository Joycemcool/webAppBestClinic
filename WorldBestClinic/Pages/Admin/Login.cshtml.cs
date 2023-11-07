using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WorldBestClinic.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? admin { get; set; }

        [BindProperty]
        public string?  password { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //
            //Check if null value in required fields
            //

            if (!ModelState.IsValid || admin == null || password == null)
            {
                return Page();
            }

            //
            //Validate admin and password
            //
            if ( admin != "admin" || password != "password")
            {
                ModelState.AddModelError("User", "Admin not found");

                return Page();
            }



            // Setup session
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin),
                new Claim("FullName", admin),
                new Claim(ClaimTypes.Role, "User")
            };

            //Standard plate - copy every time
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
                new AuthenticationProperties());

            return RedirectToPage("/Services/Index");
        }
    }
}
