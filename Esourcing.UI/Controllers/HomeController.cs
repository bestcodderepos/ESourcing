using ESourcing.Core.Entities;
using ESourcing.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Esourcing.UI.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<AppUser> _userManager { get; }
        public SignInManager<AppUser> _signInManager { get; }

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
                        //return RedirectToAction("Index");
                        return LocalRedirect(returnUrl);
                    }
                    else
                        ModelState.AddModelError("", "Email address is not valid or password");
                }
                else
                    ModelState.AddModelError("", "Email address is not valid or password");
            }
            return View();
        }


        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(AppUserViewModel signupModel)
        {
            if (ModelState.IsValid)
            {
                AppUser usr = new AppUser();
                usr.FirstName = signupModel.FirstName;
                usr.Email = signupModel.Email;
                usr.LastName = signupModel.LastName;
                usr.PhoneNumber = signupModel.PhoneNumber;
                usr.UserName = signupModel.UserName;
                if (signupModel.UserSelectTypeId == 1)
                {
                    usr.IsBuyer = true;
                    usr.IsSeller = false;
                }
                else
                {
                    usr.IsSeller = true;
                    usr.IsBuyer = false;
                }

                var result = await _userManager.CreateAsync(usr, signupModel.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(signupModel);
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
