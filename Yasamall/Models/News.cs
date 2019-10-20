using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class News
    {
        public int Id { get; set; }

        public int BrandsId { get; set; }
        public virtual Brands Brand { get; set; }

        [Required(ErrorMessage ="Xəbərin başlığı boş ola bilməz."), StringLength(100, ErrorMessage = "Xəbərin başlığı 100 simvoldan çox  ola bilməz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Xəbərin mətni boş ola bilməz.")]
        public string MainInfo { get; set; }

        [Required(ErrorMessage = "Xəbərin məlumat hissəsi boş ola bilməz."), StringLength(200, ErrorMessage = "Xəbərin məlumat hissəsi 200 simvoldan çox ola bilməz.")]
        public string ShortInfo { get; set; }

        public DateTime Time { get; set; }

        public virtual ICollection<NewsPhotos> Photos { get; set; }

        [NotMapped]
        public ICollection<IFormFile> AllPhotos { get; set; }
    }
}
