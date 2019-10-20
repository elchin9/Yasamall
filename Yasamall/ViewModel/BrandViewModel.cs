using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class BrandViewModel
    {
        public IEnumerable<Brands> Brands { get; set; }
        public IEnumerable<Tags> Tags { get; set; }
    }
}
