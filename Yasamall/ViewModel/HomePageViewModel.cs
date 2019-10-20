using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class HomePageViewModel
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<NewProducts> NewProducts { get; set; }
        public BackgroundImages Image { get; set; }
    }
}
