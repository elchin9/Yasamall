using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class ProTags
    {
        public Brands Brand { get; set; }
        public IEnumerable<BrandTags> BrandTags { get; set; }
        public IEnumerable<Products> Products { get; set; }
        public AppUser User { get; set; }
        public int Skip { get; set; }
    }
}
