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
            //Validate admin and password
            //
            if (admin == null || admin != "admin")
            {
                ModelState.AddModelError("User", "Admin not found");

                return Page();
            }

            else if (password == null || password != "password")
            {
                ModelState.AddModelError("Password", "Not a valid password");

                return Page();
            }

            // Setup session
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, dbUser.UserId.ToString()),
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
