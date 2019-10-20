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
    public class NewProductController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly IHostingEnvironment _env;

        public NewProductController(Db_Yasamall context,
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

            return View(_context.NewProducts);
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
            ViewBag.Active = "Site";

            
            //IEnumerable<Products> product = _context.Products.Where(p => p.Brands.CategoryId != 2);

            //foreach (var n in _context.NewProducts)
            //{
            //    foreach (var p in product)
            //    {
            //        if(n.ProductsId != p.Id)
            //        {
            //            if (!product.Contains(p))
            //            {
            //                product.Add(p);
            //            }
            //        }
            //        else
            //        {
            //            product.Remove(p);
            //        }
            //    }

            //}

            ViewBag.Product = _context.Products.Where(p => p.Brands.CategoryId != 2);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewProducts product)
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
                ViewBag.Active = "Site";
                ViewBag.Product =  _context.Products.Where(p => p.Brands.CategoryId != 2);

                return View(product);

            }

            Products currentProduct = await _context.Products.FindAsync(product.ProductsId);

            foreach(var n in _context.NewProducts)
            {
                if(n.ProductsId == currentProduct.Id)
                {
                    ViewBag.Active = "Site";
                    ViewBag.Product = _context.Products.Where(p => p.Brands.CategoryId != 2);

                    ModelState.AddModelError("ProductsId", "Bu məhsul onsuzda yeniliklərdə olduğu üçün yenidən əlavə edilə bilməz.");

                    return View(product);
                }
            }

            NewProducts mynews = new NewProducts()
            {
               ProductsId = product.ProductsId
            };

            await _context.NewProducts.AddAsync(mynews);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            NewProducts news = await _context.NewProducts.FindAsync(id);

            if (news == null) return View("Error");
            ViewBag.Active = "Site";

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
            NewProducts news = await _context.NewProducts.FindAsync(id);

            _context.NewProducts.Remove(news);
            await _context.SaveChangesAsync();

            ViewBag.Active = "Site";

            return RedirectToAction(nameof(Index));
        }

    }
}