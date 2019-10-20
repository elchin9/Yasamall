using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.DAL;

namespace Yasamall.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly Db_Yasamall _context;

        public ContactViewComponent(Db_Yasamall context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contact = _context.StaticData.FirstOrDefault();

            return View(await Task.FromResult(contact));
        }
    }
}
