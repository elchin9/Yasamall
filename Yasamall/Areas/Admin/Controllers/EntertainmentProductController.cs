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

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EntertainmentProductController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _env;

        public EntertainmentProductController(Db_Yasamall context,
                                 UserManager<AppUser> userManager,
                                 IHostingEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> Index(int? id)
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

            return View(brand);
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

            Products product = await _context.Products.FindAsync(id);

            if (product == null) return View("Error");

            return View(product);
        }

        public IActionResult Create(int? id)
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

            ViewBag.Brand = _context.Brands.Where(b => b.Id == id);
            ViewBag.Hall = _context.Halls;
            ViewBag.Film = _context.Brands.FirstOrDefault(b => b.Id == id).IsFilm;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products product)
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
                ViewBag.Hall = _context.Halls;
                ViewBag.Film = _context.Brands.FirstOrDefault(b => b.Id == product.BrandsId).IsFilm;
                ViewBag.Brand = _context.Brands.Where(b => b.Id == product.BrandsId);

                return View(product);
            }

            if (product.AllPhotos == null)
            {
                ViewBag.Active = "Home";
                ViewBag.Hall = _context.Halls;
                ViewBag.Film = _context.Brands.FirstOrDefault(b => b.Id == product.BrandsId).IsFilm;
                ViewBag.Brand = _context.Brands.Where(b => b.Id == product.BrandsId);

                ModelState.AddModelError("AllPhotos", "Xahiş olunur şəkil əlavə edin.");

                return View(product);
            }
           

            Products myProduct = new Products()
            {
                Name = product.Name,
                Info = product.Info,
                Price = product.Price,
                BrandsId = product.BrandsId,
            };

            await _context.Products.AddAsync(myProduct);

            if (product.HallsId != null)
            {
                myProduct.HallsId = product.HallsId;
            }

            bool isMain = true;

            foreach (var p in product.AllPhotos)
            {
                if (p != null)
                {
                    if (p.ContentType.Contains("image/"))
                    {
                        string filename = await p.SaveAsync(_env.WebRootPath);

                        ProductPhoto img = new ProductPhoto()
                        {
                            ProductsId = myProduct.Id,
                            PhotoURL = filename
                        };

                        if (isMain == true)
                        {
                            img.IsMain = true;
                        }
                        isMain = false;

                        await _context.ProductPhoto.AddAsync(img);
                    }
                }
            }

            Brands brand = await _context.Brands.FindAsync(myProduct.BrandsId);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = brand.Id });
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

            Products product = _context.Products.Find(id);

            ViewBag.Hall = _context.Halls;

            return View(product);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Products product)
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

                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                return View(product);
            }

            Products newProduct = await _context.Products.FindAsync(product.Id);

            Brands brand = await _context.Brands.FindAsync(newProduct.BrandsId);

            if (newProduct == null) return View("Error");

            if (product.AllPhotos != null)
            {

                IEnumerable<ProductPhoto> myPhoto = newProduct.Photos.Where(b => b.ProductsId == newProduct.Id);


                foreach (var photo in myPhoto)
                {
                    string computerPhoto = Path.Combine(_env.WebRootPath, "img", photo.PhotoURL);

                    if (System.IO.File.Exists(computerPhoto))
                    {
                        System.IO.File.Delete(computerPhoto);
                    }

                    _context.RemoveRange(myPhoto);
                }

                bool isMain = true;

                foreach (var p in product.AllPhotos)
                {
                    if (p != null)
                    {
                        if (p.ContentType.Contains("image/"))
                        {
                            string filename = await p.SaveAsync(_env.WebRootPath);

                            ProductPhoto img = new ProductPhoto()
                            {
                                ProductsId = newProduct.Id,
                                PhotoURL = filename
                            };

                            if (isMain == true)
                            {
                                img.IsMain = true;
                            }
                            isMain = false;

                            await _context.ProductPhoto.AddAsync(img);
                        }
                    }
                }
            }

            newProduct.Name = product.Name;
            newProduct.Info = product.Info;
            newProduct.Price = product.Price;
            newProduct.HallsId = product.HallsId;

   
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = brand.Id });
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

            Products product = await _context.Products.FindAsync(id);

            if (product == null) return View("Error");

            return View(product);
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

            IEnumerable<NewProducts> newProducts = _context.NewProducts.Where(p => p.ProductsId == id);

            _context.NewProducts.RemoveRange(newProducts);

            Products product = await _context.Products.FindAsync(id);

            IEnumerable<ProductPhoto> myPhoto = product.Photos.Where(b => b.ProductsId == product.Id);


            foreach (var photo in myPhoto)
            {
                string computerPhoto = Path.Combine(_env.WebRootPath, "img", photo.PhotoURL);

                if (System.IO.File.Exists(computerPhoto))
                {
                    System.IO.File.Delete(computerPhoto);
                }
                _context.RemoveRange(myPhoto);

            }

            IEnumerable<ProductPhoto> productPhotos = _context.ProductPhoto.Where(p => p.ProductsId == id);

            _context.ProductPhoto.RemoveRange(productPhotos);

            Brands brand = await _context.Brands.FindAsync(product.BrandsId);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();


            return RedirectToAction("Index", brand);
        }
    }
}