using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.DAL;

namespace Yasamall.ViewComponents
{
    public class SocialViewComponent : ViewComponent
    {
        private readonly Db_Yasamall _context;

        public SocialViewComponent(Db_Yasamall context)
        {
                _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var social = _context.StaticData.FirstOrDefault();

            return View(await Task.FromResult(social));
        }
    }
}
