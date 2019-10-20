using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Kateqoriyanın adı mütləq doldurulmalıdır."), StringLength(100, ErrorMessage ="Kateqoriyanın adı 100 simvoldan çox ola bilməz")]
        public string Name { get; set; }

        public virtual ICollection<Brands> Brands { get; set; }
    }
}
