using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class ProductSizes
    {
        public int Id { get; set; }

        public int ProductsId { get; set; }
        public virtual Products Product { get; set; }

        public int SizesId { get; set; }
        public virtual Sizes Size { get; set; }
    }
}
