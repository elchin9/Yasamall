using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class BrandTags
    {
        public int Id { get; set; }

        public int? BrandId { get; set; }
        public virtual Brands Brand { get; set; }

        public int? TagsId { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
