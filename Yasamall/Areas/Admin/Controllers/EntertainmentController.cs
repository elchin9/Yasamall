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

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EntertainmentController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _env;

        public EntertainmentController(Db_Yasamall context, 
                                       IHostingEnvironment env,
                                       UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            return View(_context.Brands.Where(b => b.CategoryId == 3));
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

            Brands brands = await _context.Brands.FindAsync(id);

            if (brands == null) return View("Error");
            ViewBag.Active = "Home";


            return View(brands);
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

            Brands brand = await _context.Brands.FindAsync(id);

            if (brand == null) return View("Error");
            ViewBag.Active = "Home";


            return View(brand);
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
            Brands brand = await _context.Brands.FindAsync(id);

            brand.IsActive = false;

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
            ViewBag.Floor = _context.Floor;
            ViewBag.User = _userManager.Users;
            ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brands brand)
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
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                return View(brand);
            }

            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                ViewBag.Active = "Home";
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                return View(brand);
            }

           
            if (!brand.Photo.IsImage())
            {
                ViewBag.Active = "Home";
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                ModelState.AddModelError("Photo", "File type should be image");
                return View(brand);
            }


            string filename = await brand.Photo.SaveAsync(_env.WebRootPath);
            brand.PhotoURL = filename;



            Brands newBrand = new Brands()
            {
                Name = brand.Name.Trim(),
                Phone = brand.Phone.Trim(),
                Website = brand.Website.Trim(),
                FacebookLink = brand.FacebookLink.Trim(),
                InstagramLink = brand.InstagramLink.Trim(),
                CategoryId = 3,
                FloorId = brand.FloorId,
                PhotoURL = filename,
                UserId = brand.UserId,
                IsFilm = brand.IsFilm,
                IsActive = true
            };

            await _context.Brands.AddAsync(newBrand);

            foreach (var c in brand.TagsId)
            {
                BrandTags tags = new BrandTags()
                {
                    BrandId = newBrand.Id,
                    TagsId = c
                };

                await _context.BrandTags.AddAsync(tags);

            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOnePage(Brands brand)
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
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                return RedirectToAction("Create", brand);
            }

            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                ViewBag.Active = "Home";
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                return RedirectToAction("Create", brand);

            }

            if (ModelState["OnePagePhoto"].ValidationState == ModelValidationState.Invalid)
            {
                ViewBag.Active = "Home";
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                return RedirectToAction("Create", brand);

            }

            if (!brand.Photo.IsImage())
            {
                ViewBag.Active = "Home";
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                ModelState.AddModelError("Photo", "File type should be image");
                return RedirectToAction("Create", brand);

            }

            if (!brand.OnePagePhoto.IsImage())
            {
                ViewBag.Active = "Home";
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                ModelState.AddModelError("Photo", "File type should be image");
                return RedirectToAction("Create", brand);

            }

            string filename = await brand.Photo.SaveAsync(_env.WebRootPath);
            brand.PhotoURL = filename;


            string infoImage = await brand.OnePagePhoto.SaveAsync(_env.WebRootPath); 
            brand.OnePagePhotoURL = infoImage;

            Brands mybrand = new Brands()
            {
                Name = brand.Name,
                Phone = brand.Phone.Trim(),
                Website = brand.Website.Trim(),
                FacebookLink = brand.FacebookLink.Trim(),
                InstagramLink = brand.InstagramLink.Trim(),
                CategoryId = 3,
                FloorId = brand.FloorId,
                PhotoURL = brand.PhotoURL,
                UserId = brand.UserId,
                OnePagePhotoURL = brand.OnePagePhotoURL,
                OnePageInfo = brand.OnePageInfo,
                IsOnePage = true,
                IsActive = true
            };

            await _context.Brands.AddAsync(mybrand);

            foreach (var c in brand.TagsId)
            {
                BrandTags tags = new BrandTags()
                {
                    BrandId = mybrand.Id,
                    TagsId = c
                };

                await _context.BrandTags.AddAsync(tags);

            }
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

            ViewBag.Floor = _context.Floor;
            ViewBag.User = _userManager.Users;
            ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

            ICollection<int?> myTagsId = new List<int?>();
            Brands brand = _context.Brands.Find(id);

            foreach (var t in _context.BrandTags.Where(b => b.BrandId == brand.Id))
            {
                myTagsId.Add(t.TagsId);
            }

            brand.TagsId = myTagsId;

            return View(brand);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Brands brand)
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
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 3);

                return View(brand);
            }

            Brands newBrand = await _context.Brands.FindAsync(brand.Id);

            if (newBrand == null) return View("Error");

            if (brand.Photo != null)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "img", newBrand.PhotoURL);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }

                string filename = await brand.Photo.SaveAsync(_env.WebRootPath);
                brand.PhotoURL = filename;
                newBrand.PhotoURL = brand.PhotoURL;
            }
            if (brand.OnePagePhoto != null)
            {
                if(newBrand.OnePagePhotoURL != null)
                {
                    string computerPhoto = Path.Combine(_env.WebRootPath, "img", newBrand.OnePagePhotoURL);

                    if (System.IO.File.Exists(computerPhoto))
                    {
                        System.IO.File.Delete(computerPhoto);
                    }
                }           

                string filename = await brand.OnePagePhoto.SaveAsync(_env.WebRootPath);
                brand.OnePagePhotoURL = filename;
                newBrand.OnePagePhotoURL = brand.OnePagePhotoURL;
                newBrand.OnePageInfo = brand.OnePageInfo;
            }

            IEnumerable<BrandTags> oldTags = _context.BrandTags.Where(p => p.BrandId == newBrand.Id);

            if (brand.TagsId != null)
            {
                _context.BrandTags.RemoveRange(oldTags);

                foreach (var c in brand.TagsId)
                {
                    BrandTags brandTags = new BrandTags()
                    {
                        BrandId = newBrand.Id,
                        TagsId = c
                    };

                    await _context.BrandTags.AddAsync(brandTags);

                }
            }

            newBrand.Name = brand.Name;
            newBrand.Phone = brand.Phone.Trim();
            newBrand.InstagramLink = brand.InstagramLink.Trim();
            newBrand.FacebookLink = brand.FacebookLink.Trim();
            newBrand.FloorId = brand.FloorId;
            newBrand.Website = brand.Website.Trim();
            newBrand.UserId = brand.UserId;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Active(int? id)
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

            Brands brand = await _context.Brands.FindAsync(id);

            if (brand == null) return View("Error");

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Active(Brands brand)
        {
            Brands newBrand = await _context.Brands.FindAsync(brand.Id);


            newBrand.IsActive = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}