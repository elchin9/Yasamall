using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class ProductColors
    {
        public int Id { get; set; }

        public int ProductsId { get; set; }
        public virtual Products Product { get; set; }

        public int ColorId { get; set; }
        public virtual Colors Color { get; set; }
    }
}
