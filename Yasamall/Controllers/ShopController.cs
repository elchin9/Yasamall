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
    public class ShopController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _env;


        public ShopController(Db_Yasamall context,
                              UserManager<AppUser> userManager,
                              IHostingEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public IActionResult Index()
        {
            ViewBag.Active = "Shop";

            BrandViewModel viewModel = new BrandViewModel()
            {
                Brands = _context.Brands.Where(b => b.CategoryId == 1 && b.IsActive == true).OrderByDescending(b => b.Id).Take(8),
                Tags = _context.Tags.Where(b => b.CategoryId == 1)
            };

            ViewBag.TotalCount = _context.Brands.Where(b => b.CategoryId == 1).Count();
            ViewBag.CategoryId = 1;

            return View(viewModel);
        }
    
        public async Task<IActionResult> ShopDetails(int? id)
        {
            if (id == null) return View("Error");

            Brands brand = await _context.Brands.FindAsync(id);

            if (brand == null) return View("Error");

            if (brand.IsActive == false) return View("Error");


            ViewBag.TotalCount = _context.Products.Where(b => b.BrandsId == brand.Id).Count();

            ViewBag.Active = "Shop";

            AppUser user = await _userManager.FindByIdAsync(brand.User.Id);

            ProTags viewModel = new ProTags()
            {
                Brand = brand,
                BrandTags = _context.BrandTags.Where(b => b.BrandId == brand.Id),
                User = user,
                Products = brand.Products.OrderByDescending(b => b.Id).Take(8)
            };


            return View(viewModel);
        }

        public async Task<IActionResult> Products(int? id)
        {
            if (id == null) return View("Error");

            Products product = await _context.Products.FindAsync(id);

            if (product == null) return View("Error");
            ViewBag.Active = "Shop";


            ProductsViewModel viewModel = new ProductsViewModel()
            {
                Product = product,
                AllProduct = _context.Products.Where(p => p.BrandsId == product.BrandsId).Take(4),
                ProColors = _context.ProductColors.Where(c => c.ProductsId == product.Id),
                ProSizes = _context.ProductSizes.Where(c => c.ProductsId == product.Id),
            };


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
            ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 1);

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
                ViewBag.Tag = _context.Tags.Where(t => t.CategoryId == 1);

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


            return RedirectToAction("ShopDetails", new { id = brand.Id });
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

            ViewBag.Active = "Home";
            ViewBag.Brand = _context.Brands.Where(b => b.Id == id);
            ViewBag.Color = _context.Colors;
            ViewBag.Size = _context.Sizes;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProColors colors)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Active = "Home";
                ViewBag.Color = _context.Colors;
                ViewBag.Brand = _context.Brands.Where(b => b.Id == colors.BrandsId);
                ViewBag.Size = _context.Sizes;
                return View(colors);
            }

            if (colors.AllPhotos == null)
            {
                ViewBag.Active = "Home";
                ViewBag.Color = _context.Colors;
                ViewBag.Size = _context.Sizes;
                ViewBag.Brand = _context.Brands.Where(b => b.Id == colors.BrandsId);

                ModelState.AddModelError("AllPhotos", "Xahiş olunur şəkil əlavə edin.");

                return View(colors);
            }

            Products myProduct = new Products()
            {
                Name = colors.Name,
                Info = colors.Info,
                Price = colors.Price,
                BrandsId = colors.BrandsId
            };

            await _context.Products.AddAsync(myProduct);

            bool isMain = true;

            foreach (var p in colors.AllPhotos)
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
            foreach (var c in colors.ColorsId)
            {
                ProductColors proColors = new ProductColors()
                {
                    ProductsId = myProduct.Id,
                    ColorId = c
                };

                await _context.ProductColors.AddAsync(proColors);

            }
            foreach (var s in colors.SizesId)
            {
                ProductSizes proSize = new ProductSizes()
                {
                    ProductsId = myProduct.Id,
                    SizesId = s
                };
                await _context.ProductSizes.AddAsync(proSize);

            }

            Brands brand = await _context.Brands.FindAsync(myProduct.BrandsId);

            await _context.SaveChangesAsync();

            return RedirectToAction("ShopDetails", new { id = brand.Id });
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

            ViewBag.Color = _context.Colors;
            ViewBag.Size = _context.Sizes;

            ICollection<int> myColorId = new List<int>();

            foreach (var p in _context.ProductColors.Where(b => b.ProductsId == product.Id))
            {
                myColorId.Add(p.ColorId);
            }

            ICollection<int> mySizeId = new List<int>();

            foreach (var p in _context.ProductSizes.Where(b => b.ProductsId == product.Id))
            {
                mySizeId.Add(p.SizesId);
            }

            ProColors color = new ProColors()
            {
                Name = product.Name,
                Info = product.Info,
                Price = product.Price,
                Photos = product.Photos,
                Id = product.Id,
                ColorsId = myColorId,
                SizesId = mySizeId
            };

            return View(color);
        }

        [ActionName("ProductEdit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEditPost(ProColors color)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Color = _context.Colors;
                ViewBag.Size = _context.Sizes;

                ModelState.AddModelError("", "Xaiş olunur düzgün doldurun.");
                return View(color);
            }

            Products newProduct = await _context.Products.FindAsync(color.Id);

            Brands brand = await _context.Brands.FindAsync(newProduct.BrandsId);

            if (newProduct == null) return View("Error");

            if (color.AllPhotos != null)
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

                foreach (var p in color.AllPhotos)
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

            newProduct.Name = color.Name;
            newProduct.Info = color.Info;
            newProduct.Price = color.Price;

            IEnumerable<ProductColors> oldColors = _context.ProductColors.Where(p => p.ProductsId == newProduct.Id);
            IEnumerable<ProductSizes> oldSizes = _context.ProductSizes.Where(p => p.ProductsId == newProduct.Id);

            if (color.ColorsId != null)
            {
                _context.ProductColors.RemoveRange(oldColors);

                foreach (var c in color.ColorsId)
                {
                    ProductColors proColors = new ProductColors()
                    {
                        ProductsId = newProduct.Id,
                        ColorId = c
                    };

                    await _context.ProductColors.AddAsync(proColors);

                }
            }
            if (color.SizesId != null)
            {
                _context.ProductSizes.RemoveRange(oldSizes);

                foreach (var s in color.SizesId)
                {
                    ProductSizes proSize = new ProductSizes()
                    {
                        ProductsId = newProduct.Id,
                        SizesId = s
                    };

                    await _context.ProductSizes.AddAsync(proSize);

                }
            }


            await _context.SaveChangesAsync();

            return RedirectToAction("ShopDetails", new { id = brand.Id });
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


            ViewBag.Active = "Home";

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            IEnumerable<ProductColors> productColors = _context.ProductColors.Where(p => p.ProductsId == id);

            _context.ProductColors.RemoveRange(productColors);

            IEnumerable<ProductSizes> productSizes = _context.ProductSizes.Where(p => p.ProductsId == id);

            _context.ProductSizes.RemoveRange(productSizes);

            IEnumerable<NewProducts> newProducts = _context.NewProducts.Where(p => p.ProductsId == id);

            _context.NewProducts.RemoveRange(newProducts);

            IEnumerable<ProductPhoto> productPhotos = _context.ProductPhoto.Where(p => p.ProductsId == id);

            _context.ProductPhoto.RemoveRange(productPhotos);

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

            Brands brand = await _context.Brands.FindAsync(product.BrandsId);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            ViewBag.Active = "Home";


            return RedirectToAction("ShopDetails", new { id = brand.Id });
        }

    }
}