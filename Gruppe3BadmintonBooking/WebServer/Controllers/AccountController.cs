using Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login([FromForm] LoginModel loginInfo, [FromQuery] string returnUrl)
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
            //    TempData.Add("Fejlbesked", "LOGIN IKKE GYLDIG");
            //    return View();
            //}

            if (loginInfo.Password == "hest")
            {
                SignIn(loginInfo);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction();
                }
            }
            return View();
        }
            private void SignIn(LoginModel user)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
        }
    }
