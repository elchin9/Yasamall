using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class ProductUserViewModel
    {
        public Brands Brand { get; set; }
        public AppUser User { get; set; }
    }
}
