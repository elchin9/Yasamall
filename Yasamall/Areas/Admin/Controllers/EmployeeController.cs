using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Yasamall.DAL;
using Yasamall.Extensions;
using Yasamall.Models;
using Yasamall.Utilities;
using Yasamall.ViewModel;

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<AppUser> _usermanager;

        public EmployeeController(Db_Yasamall context,
                                       IHostingEnvironment env,
                                       UserManager<AppUser> usermanager,
                                       SignInManager<AppUser> signinManager)
        {
            _context = context;
            _env = env;
            _usermanager = usermanager;
            _signinManager = signinManager;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Active = "Home";

            return View(_usermanager.Users);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null) return View("Error");

            AppUser user = await _usermanager.FindByIdAsync(id);

            if (user == null) return View("Error");
            ViewBag.Active = "Home";

            return View(user);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGet(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null) return View("Error");

            AppUser user = await _usermanager.FindByIdAsync(id);

            if (user == null) return View("Error");
            ViewBag.Active = "Home";


            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            AppUser user = await _usermanager.FindByIdAsync(id);

            if (user.PhotoURL != null)
            {
                if(user.PhotoURL != "Person-icon.png")
                {
                    string computerPhoto = Path.Combine(_env.WebRootPath, "img", user.PhotoURL);

                    if (System.IO.File.Exists(computerPhoto))
                    {
                        System.IO.File.Delete(computerPhoto);
                    }
                }
              
            }

            await _usermanager.DeleteAsync(user);
            await _context.SaveChangesAsync();
            ViewBag.Active = "Home";


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Active = "Home";

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel registerViewModel)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Active = "Home";

                return View(registerViewModel);
            }

            AppUser newUser;

            if ( registerViewModel.Photo != null)
            {
                if (!registerViewModel.Photo.IsImage())
                {
                    ViewBag.Active = "Home";

                    ModelState.AddModelError("Photo", "File type should be image");
                    return View(registerViewModel);
                }

                string filename = await registerViewModel.Photo.SaveAsync(_env.WebRootPath);
                registerViewModel.PhotoURL = filename;

                newUser = new AppUser
                {
                    Firstname = registerViewModel.Firstname.Trim(),
                    Lastname = registerViewModel.Lastname.Trim(),
                    Email = registerViewModel.Email.Trim(),
                    UserName = registerViewModel.Username.Trim(),
                    PhoneNumber = registerViewModel.Phone.Trim(),
                    PhotoURL = registerViewModel.PhotoURL
                };
            }
            else
            {
                newUser = new AppUser
                {
                    Firstname = registerViewModel.Firstname.Trim(),
                    Lastname = registerViewModel.Lastname.Trim(),
                    Email = registerViewModel.Email.Trim(),
                    UserName = registerViewModel.Username.Trim(),
                    PhoneNumber = registerViewModel.Phone.Trim(),
                    PhotoURL = "Person-icon.png"
                };
            }

            

            IdentityResult identityResult = await _usermanager.CreateAsync(newUser, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ViewBag.Active = "Home";

                return View(registerViewModel);
            }

            //add default member role to user

            await _usermanager.AddToRoleAsync(newUser, StaticUsers.Member);
            ViewBag.Active = "Home";


            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (id == null) return View("Error");


            AppUser user = await _usermanager.FindByIdAsync(id);

            if (user == null) return View("Error");

          
            return View(user);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(AppUser user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");

                return View(user);
            }

            AppUser newUser = await _usermanager.FindByIdAsync(user.Id);

            if (newUser == null) return View("Error");

            if (user.Photo != null)
            {
                if(newUser.PhotoURL != null)
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
            newUser.UserName = user.UserName.Trim();
            newUser.PhoneNumber = user.PhoneNumber.Trim();
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}