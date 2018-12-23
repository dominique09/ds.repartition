using System.Threading.Tasks;
using DS.Repartition.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DS.Repartition.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                    return LocalRedirect(returnUrl);

                ModelState.AddModelError(string.Empty, "Nom d'utilisateur ou mot de passe invalide.");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            return returnUrl != null ? LocalRedirect(returnUrl) : RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();
    }
}
