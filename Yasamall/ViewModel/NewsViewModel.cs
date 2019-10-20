using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class NewsViewModel
    {
        public News News { get; set; }
        public IEnumerable<News> AllNews { get; set; }
    }
}
