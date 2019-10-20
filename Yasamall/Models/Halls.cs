using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class Halls
    {
        public int Id { get; set; }

        [Required(), StringLength(100)]
        public string Name { get; set; }

        public int BrandId { get; set; }
        public virtual Brands Brand { get; set; }

        public virtual ICollection<Products> Product { get; set; }
    }
}
