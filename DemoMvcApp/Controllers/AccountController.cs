using DemoMvcApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManager)
        {
            _userManger = userManger;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManger.FindByNameAsync(model.UserName);
                if (user != null && await _userManger.CheckPasswordAsync(user, model.Password))
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exists = await _userManger.FindByNameAsync(model.UserName);
                if (exists == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = model.UserName,
                        NormalizedUserName = model.UserName.ToUpper(),
                        Email = model.Email,
                        NormalizedEmail = model.Email.ToUpper(),
                    };

                    var result = await _userManger.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        result = await _userManger.AddToRoleAsync(user, "User");
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Dashboard");
                    }

                    result.Errors.Select(e => e.Description).ToList().ForEach(e => ModelState.AddModelError(string.Empty, e));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User already exists.");
                }
            }

            return View(model);
        }
    }
}
