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
    public class ProductController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _env;

        public ProductController(Db_Yasamall context,
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

            ProductsViewModel viewModel = new ProductsViewModel()
            {
                Product = product,
                ProColors = _context.ProductColors.Where(c => c.ProductsId == product.Id),
                ProSizes = _context.ProductSizes.Where(c => c.ProductsId == product.Id),
            };

            return View(viewModel);
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
            ViewBag.Color = _context.Colors;
            ViewBag.Size = _context.Sizes;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProColors colors)
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
            foreach(var c in colors.ColorsId)
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

            return RedirectToAction("Index", new { id = brand.Id});
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

            ViewBag.Color = _context.Colors;
            ViewBag.Size = _context.Sizes;

            ICollection<int> myColorId = new List<int>();

            foreach(var p in _context.ProductColors.Where(b => b.ProductsId == product.Id))
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

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(ProColors color)
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

            if(color.ColorsId != null)
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
            if(color.SizesId != null)
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
            IEnumerable<ProductColors> productColors =  _context.ProductColors.Where(p => p.ProductsId == id);

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


            return RedirectToAction("Index", brand);
        }

    }
}