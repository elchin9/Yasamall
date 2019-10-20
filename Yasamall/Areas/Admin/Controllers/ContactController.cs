using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Yasamall.DAL;
using Yasamall.Models;

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly IHostingEnvironment _env;

        public ContactController(Db_Yasamall context,
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
            ViewBag.Active = "Site";
            return View(_context.StaticData.FirstOrDefault());
        }

        [ActionName("Edit")]
        public IActionResult Edit(int? id)
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

            StaticData sd = _context.StaticData.Find(id);

            return View(sd);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(StaticData sd)
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
                return View(sd);
            }

            StaticData newsSd = await _context.StaticData.FindAsync(sd.Id);

            if (newsSd == null) return View("Error");

            newsSd.Email = sd.Email.Trim();
            newsSd.FacebookLink = sd.FacebookLink.Trim();
            newsSd.TwitterLink = sd.TwitterLink.Trim();
            newsSd.InstagramLink = sd.InstagramLink.Trim();
            newsSd.YoutubeLink = sd.YoutubeLink.Trim();
            newsSd.Map = sd.Map.Trim();
            newsSd.Mobile = sd.Mobile.Trim();
            newsSd.Phone = sd.Phone.Trim();

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}