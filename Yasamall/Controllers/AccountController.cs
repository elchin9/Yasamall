using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yasamall.DAL;
using Yasamall.Extensions;
using Yasamall.Models;
using Yasamall.ViewModel;

namespace Yasamall.Controllers
{
    public class AccountController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _env;


        public AccountController(Db_Yasamall context,
                                 UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signinManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IHostingEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _env = env;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> MyProfile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileViewModel viewModel = new ProfileViewModel()
            {
                User = user,
                Brand = _context.Brands.Where(b => b.UserId == user.Id)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> EditProfile(string id)
        {
            if (id == null) return View("Error");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            AppUser user = await _userManager.FindByIdAsync(id);

            if (User.Identity.Name != user.UserName)
            {
                return RedirectToAction("Error", "Home");
            }

            ChangeProfileViewModel viewModel = new ChangeProfileViewModel()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Username = user.UserName,
                PhotoURL = user.PhotoURL
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(ChangeProfileViewModel user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");

                return View(user);
            }

            string activeUsername = User.Identity.Name;

            AppUser newUser = await _userManager.FindByNameAsync(activeUsername);

            if (newUser == null) return View("Error");

            if (user.Photo != null)
            {
               
                if (newUser.PhotoURL != null)
                {
                    if (newUser.PhotoURL != "Person-icon.png")
                    {

                        string computerPhoto = Path.Combine(_env.WebRootPath, "img", newUser.PhotoURL);

                        if (System.IO.File.Exists(computerPhoto))
                        {
                            System.IO.File.Delete(computerPhoto);
                        }
                    }

                }

                string filename = await user.Photo.SaveAsync(_env.WebRootPath);
                user.PhotoURL = filename;
                newUser.PhotoURL = user.PhotoURL;
            }

            newUser.Email = user.Email.Trim();
            newUser.Firstname = user.Firstname.Trim();
            newUser.Lastname = user.Lastname.Trim();
            newUser.UserName = user.Username.Trim();
            newUser.PhoneNumber = user.Phone.Trim();

            await _userManager.UpdateAsync(newUser);


            if (user.CurrentPassword != null && user.Password != null)
            {
                if(user.CurrentPassword == user.Password)
                {
                    ModelState.AddModelError("Password","Yeni şifrə köhnə şifrə ilə eyni ola bilməz.");
                    return View(user);
                }

                string current = user.CurrentPassword.Trim();
                string mynew = user.Password.Trim();

                IdentityResult result = await _userManager.ChangePasswordAsync(newUser, current, mynew);
               
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("CurrentPassword", "Hazırki şifrə yanlışdır və ya yeni şifrə tələblərə uyğun deyil.");
                        ModelState.AddModelError("Password", "Hazırki şifrə yanlışdır və ya yeni şifrə tələblərə uyğun deyil.");
                        return View(user);
                    }

                await _userManager.UpdateAsync(newUser);
            }

            
            return RedirectToAction("MyProfile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel LoginViewModel)
        {
            if (!ModelState.IsValid) return View(LoginViewModel);

            AppUser user = await _userManager.FindByEmailAsync(LoginViewModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is invalid");
                return View(LoginViewModel);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                 await _signinManager.PasswordSignInAsync(user, LoginViewModel.Password, LoginViewModel.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is invalid");
                return View(LoginViewModel);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}