using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZipLink.Client.Data.ViewModel;
using ZipLink.Client.Helpers.Roles;
using ZipLink.Data;
using ZipLink.Data.Models;
using ZipLink.Data.Services;

namespace ZipLink.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        
        private IUserService _userService;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public AuthenticationController(IUserService userService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Users()
        {
            var users =await _userService.GetUsersAsync();
            return View(users);
        }

        //Render
        public async Task<IActionResult> Login()
        {
            return View(new LoginVM());
        }

        //Handle
        public async Task<IActionResult> LoginSubmitted(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var userPasswordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (userPasswordCheck)
                {
                    var loggedInUser = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (loggedInUser.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login attempt, check your username or password");
                        return View("Login", loginVM);
                    }
                }
                else
                {
                    await _userManager.AccessFailedAsync(user);

                    if(await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Account locked, please try again in 10 minutes");
                        return View("Login", loginVM);
                    }
                    ModelState.AddModelError("", "Invalid Login attempt, check your username or password");
                    return View("Login", loginVM);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        //Render
        public async Task<IActionResult> Register()
        {
            return View(new RegisterVM());
        }

        public async Task<IActionResult> RegisterUser(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", registerVM);
            }

            //Check if user exits
            var userExists = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (userExists != null)
            {
                ModelState.AddModelError("", "Email Address is already in use");
                return View("Register", registerVM);
            }

                var newUser = new AppUser()
                {
                    Email = registerVM.EmailAddress,
                    UserName = registerVM.EmailAddress,
                    FullName = registerVM.FullName,
                    LockoutEnabled=true
                };

            var userCreated = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (userCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, Role.User);

                //Sign in user
                await _signInManager.PasswordSignInAsync(newUser, registerVM.Password, false, false);
            }
            else
            {
                foreach(var error in userCreated.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

                return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
