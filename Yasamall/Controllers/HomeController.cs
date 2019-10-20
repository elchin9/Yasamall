using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yasamall.DAL;
using Yasamall.Extensions;
using Yasamall.Models;
using Yasamall.ViewModel;

namespace Yasamall.Controllers
{
    public class HomeController : Controller
    {
        private readonly Db_Yasamall _context;
        private readonly IHostingEnvironment _env;

        public HomeController(Db_Yasamall context,
                              IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            HomePageViewModel viewModel = new HomePageViewModel()
            {
                News = _context.News.OrderByDescending(n => n.Id).Take(4),
                NewProducts = _context.NewProducts.OrderByDescending(n => n.Id).Take(4),
                Image = await _context.BackgroundImages.FirstOrDefaultAsync()
            };

            ViewBag.Active = "Home";

            return View(viewModel);
        }

        public IActionResult Contact()
        {
            ViewBag.Active = "Contact";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(MailBox message)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Active = "Contact";

                return View(message);
            }

            MailBox mynews = new MailBox()
            {
                Firstname = message.Firstname,
                Lastname = message.Lastname,
                Email = message.Email,
                TextBody = message.TextBody,
                Time = DateTime.Now
            };

            await _context.MailBox.AddAsync(mynews);
        
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
