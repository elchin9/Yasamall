using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class Products
    {
        public int  Id{ get; set; }

        [Required(ErrorMessage ="Məhsulun adı mütləq doldurulmalıdır."), StringLength(100,ErrorMessage ="Məhsulun adı 100 simvoldan çox ola bilməz")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Məhsul haqqında mütləq informasiya verilməlidir.")]
        public string Info { get; set; }

        public decimal Price { get; set; }

        public int BrandsId { get; set; }
        public virtual Brands Brands { get; set; }

        public int? HallsId { get; set; }
        public virtual Halls Hall { get; set; }

        public virtual ICollection<ProductPhoto> Photos { get; set; }

        [NotMapped]
        public ICollection<IFormFile> AllPhotos { get; set; }
    }
}
