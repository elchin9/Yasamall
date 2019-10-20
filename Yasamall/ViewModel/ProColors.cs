using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.ViewModel
{
    public class ProColors
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Info { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int BrandsId { get; set; }

        [Required]
        public  IEnumerable<int> ColorsId { get; set; }

        [Required]
        public IEnumerable<int> SizesId { get; set; }

        public virtual ICollection<ProductPhoto> Photos { get; set; }

        [NotMapped]
        public ICollection<IFormFile> AllPhotos { get; set; }
    }
}
