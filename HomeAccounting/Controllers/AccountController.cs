using HomeAccounting.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUser user)
    {
        if (ModelState.IsValid)
        {
            var userLooked = await _userManager.FindByEmailAsync(user.Email);

            if (userLooked is null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(user);
            }

            var result = await _userManager.CheckPasswordAsync(userLooked, user.Password);

            if (result)
            {
                await _signInManager.SignInAsync(userLooked, true);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
        }

        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

}
