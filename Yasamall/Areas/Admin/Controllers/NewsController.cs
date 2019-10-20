using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Yasamall.DAL;
using Yasamall.Extensions;
using Yasamall.Models;

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly IHostingEnvironment _env;

        public NewsController(Db_Yasamall context,
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

            return View(_context.News);
        }

        public async Task<IActionResult> Details(int? id)
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

            News news = await _context.News.FindAsync(id);

            if (news == null) return View("Error");
            ViewBag.Active = "Home";


            return View(news);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGet(int? id)
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

            News news = await _context.News.FindAsync(id);

            if (news == null) return View("Error");
            ViewBag.Active = "Home";

            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }
            News news = await _context.News.FindAsync(id);

            IEnumerable<NewsPhotos> myPhoto = news.Photos.Where(b => b.NewsId == news.Id);

            foreach (var photo in myPhoto)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "img", photo.PhotoURL);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }
                _context.RemoveRange(myPhoto);

            }

            _context.News.Remove(news);

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
            ViewBag.Brand = _context.Brands;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
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

                return View(news);
            }

            //if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            //{
            //    ViewBag.Active = "Home";

            //    return View(news);
            //}

            //if (!news.Photo.IsImage())
            //{
            //    ViewBag.Active = "Home";

            //    ModelState.AddModelError("Photo", "File type should be image");
            //    return View(news);
            //}

            //string filename = await news.Photo.SaveAsync(_env.WebRootPath);
            //news.PhotoURL = filename;

            News mynews = new News()
            {
               Title = news.Title,
               ShortInfo = news.ShortInfo,
               MainInfo = news.MainInfo,
               Time = DateTime.Now,
               BrandsId = news.BrandsId
            };

            await _context.News.AddAsync(mynews);

            bool isMain = true;

            foreach (var p in news.AllPhotos)
            {
                if (p != null)
                {
                    if (p.ContentType.Contains("image/"))
                    {
                        string filenamePhotos = await p.SaveAsync(_env.WebRootPath);

                        NewsPhotos img = new NewsPhotos()
                        {
                            NewsId = mynews.Id,
                            PhotoURL = filenamePhotos,
                        };
                        if (isMain == true)
                        {
                            img.IsMain = true;
                        }
                        isMain = false;

                        await _context.NewsPhotos.AddAsync(img);
                    }
                }
            }

            ViewBag.Active = "Home";

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            ViewBag.Brand = _context.Brands;

            News news = _context.News.Find(id);

            return View(news);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(News news)
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
                return View(news);
            }

            News mynews = await _context.News.FindAsync(news.Id);

            if (mynews == null) return View("Error");

            mynews.Title = news.Title;
            mynews.ShortInfo = news.ShortInfo;
            mynews.MainInfo = news.MainInfo;
            mynews.BrandsId = news.BrandsId;
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}