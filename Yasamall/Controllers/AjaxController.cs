using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yasamall.DAL;
using Yasamall.Models;
using Yasamall.ViewModel;

namespace Yasamall.Controllers
{
    public class AjaxController : Controller
    {

        private readonly Db_Yasamall _context;
        private readonly UserManager<AppUser> _userManager;

        public AjaxController(Db_Yasamall context,
                              UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult LoadBrandsbyTagsId(int tagsId)
        {
            return PartialView("_SelectBrandsPartialView", _context.BrandTags.Where(c => c.TagsId == tagsId && c.Brand.IsActive == true));
        }

        [HttpPost]
        public IActionResult LoadAllBrands(int categoryId)
        {
            return PartialView("_AllBrandsPartialView", _context.Brands.Where(b => b.CategoryId == categoryId && b.IsActive == true).OrderByDescending(b => b.Id).Take(8));
        }

        public IActionResult LoadBrands(int skip)
        {

            var model =
                _context.Brands.Where(b => b.CategoryId == 1 && b.IsActive == true).OrderByDescending(b => b.Id).Skip(skip).Take(4);

            return PartialView("_ShopPartialView", model);
        }

        public async Task<IActionResult> LoadProducts(int skip, int brandId, int userId)
        {
            Brands brand = await _context.Brands.FindAsync(brandId);

            AppUser user = await _userManager.FindByIdAsync(brand.User.Id);

            ProTags model = new ProTags()
            {
                Products = _context.Products.Where(b => b.BrandsId == brandId).OrderByDescending(p => p.Id).Skip(skip).Take(4),
                User = user
            };

            return PartialView("_ProductsPartialView", model);
        }

        public IActionResult LoadNews(int skip)
        {
            var model =
                _context.News.OrderByDescending(b => b.Id).Skip(skip).Take(8);

            return PartialView("_NewsPartialView", model);
        }

        public IActionResult LoadRestaurantBrands(int skip)
        {

            var model =
                _context.Brands.Where(b => b.CategoryId == 2 && b.IsActive == true).OrderByDescending(b => b.Id).Skip(skip).Take(4);

            return PartialView("_RestaurantPartialView", model);
        }

        public async Task<IActionResult> LoadRestaurantProducts(int skip, int brandId, int userId)
        {
            Brands brand = await _context.Brands.FindAsync(brandId);

            AppUser user = await _userManager.FindByIdAsync(brand.User.Id);

            ProTags model = new ProTags()
            {
                Products = _context.Products.Where(b => b.BrandsId == brandId).OrderByDescending(p => p.Id).Skip(skip).Take(4),
                User = user
            };

            return PartialView("_RestaurantProductsPartialView", model);
        }

        public IActionResult LoadEntertainmentBrands(int skip)
        {

            var model =
                _context.Brands.Where(b => b.CategoryId == 3 && b.IsActive == true).OrderByDescending(b => b.Id).Skip(skip).Take(4);

            return PartialView("_EntertainmentPartialView", model);
        }

        public async Task<IActionResult> LoadEntertainmentProducts(int skip, int brandId, int userId)
        {
            Brands brand = await _context.Brands.FindAsync(brandId);

            AppUser user = await _userManager.FindByIdAsync(brand.User.Id);

            ProTags model = new ProTags()
            {
                Products = _context.Products.Where(b => b.BrandsId == brandId).OrderByDescending(p => p.Id).Skip(skip).Take(4),
                User = user
            };

            return PartialView("_EntertainmentProductsPartialView", model);
        }


    }
}