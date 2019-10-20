using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class ProductsViewModel
    {
        public Products Product { get; set; }
        public IEnumerable<Products> AllProduct { get; set; }
        public IEnumerable<ProductColors> ProColors { get; set; }
        public IEnumerable<ProductSizes> ProSizes { get; set; }
    }
}
