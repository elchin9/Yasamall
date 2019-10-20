using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class ProfileViewModel
    {
        public AppUser User { get; set; }
        public IEnumerable<Brands> Brand { get; set; }
    }
}
