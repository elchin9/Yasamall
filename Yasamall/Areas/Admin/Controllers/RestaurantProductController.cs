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
using Yasamall.ViewModel;

namespace Yasamall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantProductController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _env;

        public RestaurantProductController(Db_Yasamall context,
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
                ViewBag.Brand = _context.Brands.Where(b => b.Id == product.BrandsId);

                return View(product);
            }

            if(product.AllPhotos == null)
            {
                ViewBag.Active = "Home";
                ViewBag.Brand = _context.Brands.Where(b =>b.Id == product.BrandsId);

                ModelState.AddModelError("AllPhotos", "Xahiş olunur şəkil əlavə edin.");

                return View(product);
            }

            Products myProduct = new Products()
            {
                Name = product.Name,
                Price = product.Price,
                Info = product.Info,
                BrandsId = product.BrandsId
            };

            await _context.Products.AddAsync(myProduct);

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

            Brands brand = await _context.Brands.FindAsync(product.BrandsId);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), brand);
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
                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                return View(product);
            }

            Products newProduct = await _context.Products.FindAsync(product.Id);
            Brands brand = await _context.Brands.FindAsync(newProduct.BrandsId);

            if (newProduct == null) return View("Error");

            if (product.AllPhotos != null)
            {

                IEnumerable<ProductPhoto> myPhoto = newProduct.Photos.Where(b => b.ProductsId == product.Id);

                
                foreach(var photo in myPhoto)
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

            await _context.SaveChangesAsync();

            

            return RedirectToAction("Index", brand);
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
            ViewBag.Active = "Home";

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

            IEnumerable<ProductPhoto> productPhotos = _context.ProductPhoto.Where(p => p.ProductsId == id);

            _context.ProductPhoto.RemoveRange(productPhotos);

            Products product = await _context.Products.FindAsync(id);

            Brands brand = await _context.Brands.FindAsync(product.BrandsId);

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


            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            ViewBag.Active = "Home";


            return RedirectToAction("Index", brand);
        }
    }
}