using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class FilmViewModel
    {
        public Products Product { get; set; }
        public IEnumerable<Products> AllProducts { get; set; }
    }
}
