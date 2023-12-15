using HomeAccounting.DataAccess.Entities;
using HomeAccounting.Models.Login;
using HomeAccounting.Models.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    public IActionResult Register() 
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterUser register)
    {
        if (ModelState.IsValid)
        {
            var user = new User()
            {
                Email = register.Email,
                LockoutEnabled = false,
                Name = register.FirstName,
                Surname = register.LastName,
                UserName = register.UserName,
                EmailConfirmed = false,
                TwoFactorEnabled = false,
                AccessFailedCount = 0
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");

                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

 
        return View(register);
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

    [HttpGet]
    public IActionResult Index()
    {
        var users = _userManager.Users.AsNoTracking().ToList();

        if (users is null)
        {
            return View();
        }

        return View(users);
    }

    [HttpGet]
   // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(string id) 
    {
        var user = await _userManager.FindByIdAsync(id);

        return View(user);
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(User userRequest) 
    {
        var user = await _userManager.FindByIdAsync(userRequest.Id);
        await _userManager.UpdateAsync(user);

        return RedirectToAction("Index", "Account");
    }

    [HttpGet]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        return View(user);
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(User userRequest)
    {
        var user = await _userManager.FindByIdAsync(userRequest.Id);
        await _userManager.DeleteAsync(user);

        return RedirectToAction("Index","Account");
    }

}
