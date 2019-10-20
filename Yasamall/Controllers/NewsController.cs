using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yasamall.DAL;
using Yasamall.Models;
using Yasamall.ViewModel;

namespace Yasamall.Controllers
{
    public class NewsController : Controller
    {
        private readonly Db_Yasamall _context;

        public NewsController(Db_Yasamall context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Active = "News";
            ViewBag.TotalCount = _context.News.Count();

            return View(_context.News.Take(16));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return View("Error");

            News news = await _context.News.FindAsync(id);

            if (news == null) return View("Error");
            ViewBag.Active = "News";

            NewsViewModel viewModel = new NewsViewModel()
            {
                News = news,
                AllNews = _context.News.Where(b => b.BrandsId == news.BrandsId && b.Id != news.Id)
            };


            return View(viewModel);
        }
    }
}