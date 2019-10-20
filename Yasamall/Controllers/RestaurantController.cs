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
    public class RestaurantController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _env;


        public RestaurantController(Db_Yasamall context,
                                    UserManager<AppUser> userManager,
                                    IHostingEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public IActionResult Index()
        {
            ViewBag.Active = "Restaurant";

            BrandViewModel viewModel = new BrandViewModel()
            {
                Brands = _context.Brands.Where(b => b.CategoryId == 2 && b.IsActive == true).OrderByDescending(b => b.Id).Take(8),
                Tags = _context.Tags.Where(b => b.CategoryId == 2)
            };

            ViewBag.TotalCount = _context.Brands.Where(b => b.CategoryId == 2).Count();
            ViewBag.CategoryId = 2;

            return View(viewModel);
        }

        public async Task<IActionResult> RestaurantDetails(int? id)
        {
            if (id == null) return View("Error");

            Brands brand = await _context.Brands.FindAsync(id);

            if (brand == null) return View("Error");

            if (brand.IsActive == false) return View("Error");


            ViewBag.Active = "Restaurant";

            AppUser user = await _userManager.FindByIdAsync(brand.User.Id);

            ProTags viewModel = new ProTags()
            {
                Brand = brand,
                BrandTags = _context.BrandTags.Where(b => b.BrandId == brand.Id),
                User = user,
                Products = brand.Products.OrderByDescending(b => b.Id).Take(8)
            };

            ViewBag.TotalCount = _context.Products.Where(b => b.BrandsId == brand.Id).Count();

            return View(viewModel);
        }

        [ActionName("Edit")]
        public IActionResult Edit(int? id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Brands brand = _context.Brands.Find(id);

            if (User.Identity.Name != brand.User.UserName)
            {
                return RedirectToAction("Error", "Home");
            }

            if (id == null) return View("Error");

            ViewBag.Floor = _context.Floor;
            ViewBag.User = _userManager.Users;
            ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 2);

            ICollection<int?> myTagsId = new List<int?>();

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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                ViewBag.Floor = _context.Floor;
                ViewBag.User = _userManager.Users;
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 2);

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
            newBrand.Phone = brand.Phone;
            newBrand.InstagramLink = brand.InstagramLink;
            newBrand.FacebookLink = brand.FacebookLink;
            newBrand.FloorId = brand.FloorId;
            newBrand.Website = brand.Website;

            await _context.SaveChangesAsync();


            return RedirectToAction("RestaurantDetails", new { id = brand.Id });
        }

        public IActionResult CreateProduct(int? id)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Brands brand = _context.Brands.Find(id);

            if (User.Identity.Name != brand.User.UserName)
            {
                return RedirectToAction("Error", "Home");
            }

            ViewBag.Brand = _context.Brands.Where(b => b.Id == id);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Products product)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Brand = _context.Brands.Where(b => b.Id == product.BrandsId);

                return View(product);
            }

            if (product.AllPhotos == null)
            {
                ViewBag.Brand = _context.Brands.Where(b => b.Id == product.BrandsId);

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

            return RedirectToAction("RestaurantDetails", new { id = brand.Id });
        }

        [ActionName("ProductEdit")]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null) return View("Error");

            Products product = _context.Products.Find(id);

            if (product == null) return View("Error");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Brands brand = _context.Brands.Find(product.BrandsId);

            if (User.Identity.Name != brand.User.UserName)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(product);
        }

        [ActionName("ProductEdit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEditPost(Products product)
        {

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

            await _context.SaveChangesAsync();



            return RedirectToAction("RestaurantDetails", new { id = brand.Id });
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGet(int? id)
        {

            if (id == null) return View("Error");

            Products product = await _context.Products.FindAsync(id);

            if (product == null) return View("Error");

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Brands brand = _context.Brands.Find(product.BrandsId);

            if (User.Identity.Name != brand.User.UserName)
            {
                return RedirectToAction("Error", "Home");
            }


            ViewBag.Active = "Restaurant";

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            IEnumerable<NewProducts> newProducts = _context.NewProducts.Where(p => p.ProductsId == id);

            _context.NewProducts.RemoveRange(newProducts);

            IEnumerable<ProductPhoto> productPhotos = _context.ProductPhoto.Where(p => p.ProductsId == id);

            _context.ProductPhoto.RemoveRange(productPhotos);

            Products product = await _context.Products.FindAsync(id);

            Brands brand = await _context.Brands.FindAsync(product.BrandsId);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return RedirectToAction("RestaurantDetails", new { id = brand.Id });
        }
    }
}