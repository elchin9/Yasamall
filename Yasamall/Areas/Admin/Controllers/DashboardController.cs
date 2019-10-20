using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Yasamall.DAL;
using Yasamall.Extensions;
using Yasamall.Models;

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly IHostingEnvironment _env;

        public DashboardController(Db_Yasamall context,
                                   IHostingEnvironment env)
        {
            _context = context;
            _env = env;
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

            return View();
        }

        public IActionResult Website()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Active = "Site";

            return View();
        }

        public IActionResult ImageIndex()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Active = "Site";

            return View(_context.BackgroundImages.FirstOrDefault());
        }

        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id)
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
            ViewBag.Active = "Site";

            BackgroundImages image = await _context.BackgroundImages.FindAsync(id);


            return View(image);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(BackgroundImages image)
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
                ViewBag.Hall = _context.Halls;
                ViewBag.Active = "Site";

                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                return View(image);
            }

            BackgroundImages currentImages = await _context.BackgroundImages.FindAsync(image.Id);

            if (image.PhotoOne != null)
            {

                string computerPhoto = Path.Combine(_env.WebRootPath, "img", currentImages.PhotoURLOne);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                if (image.PhotoOne.ContentType.Contains("image/"))
                {
                    string filename = await image.PhotoOne.SaveAsync(_env.WebRootPath);

                    currentImages.PhotoURLOne = filename;

                }

            }
            if (image.PhotoTwo != null)
            {

                string computerPhoto = Path.Combine(_env.WebRootPath, "img", currentImages.PhotoURLTwo);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                if (image.PhotoTwo.ContentType.Contains("image/"))
                {
                    string filename = await image.PhotoTwo.SaveAsync(_env.WebRootPath);

                    currentImages.PhotoURLTwo = filename;

                }

            }
            if (image.PhotoThree != null)
            {

                string computerPhoto = Path.Combine(_env.WebRootPath, "img", currentImages.PhotoURLThree);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                if (image.PhotoThree.ContentType.Contains("image/"))
                {
                    string filename = await image.PhotoThree.SaveAsync(_env.WebRootPath);

                    currentImages.PhotoURLThree = filename;

                }

            }
            if (image.PhotoFour != null)
            {

                string computerPhoto = Path.Combine(_env.WebRootPath, "img", currentImages.PhotoURLFour);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                if (image.PhotoFour.ContentType.Contains("image/"))
                {
                    string filename = await image.PhotoFour.SaveAsync(_env.WebRootPath);

                    currentImages.PhotoURLFour = filename;

                }

            }
            if (image.PhotoFive != null)
            {

                string computerPhoto = Path.Combine(_env.WebRootPath, "img", currentImages.PhotoURLFive);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                if (image.PhotoFive.ContentType.Contains("image/"))
                {
                    string filename = await image.PhotoFive.SaveAsync(_env.WebRootPath);

                    currentImages.PhotoURLFive = filename;

                }

            }

            await _context.SaveChangesAsync();

            return RedirectToAction("ImageIndex");

        }
    }
}