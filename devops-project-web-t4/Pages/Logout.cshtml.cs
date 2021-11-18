// Pages/Logout.cshtml.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace devops_project_web_t4.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task OnGet()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties { RedirectUri = "/" });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}