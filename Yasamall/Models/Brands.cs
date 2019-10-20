using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class Brands
    {
        public int Id { get; set; }

        public string PhotoURL { get; set; }

        public string OnePagePhotoURL { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        [Required(ErrorMessage = "Mağazanın Adı mütləq doldurulmalıdır."), StringLength(100, ErrorMessage = "Mağazanın Adı 100 hərfdən çox ola bilməz.")]
        public string Name { get; set; }

        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }

        [Required(ErrorMessage = "Mağazanın nömrəsi mütləq doldurulmalıdır."), StringLength(20, ErrorMessage = "Mağazanın nömrəsi 20 simvoldan çox ola bilməz.")]
        public string Phone { get; set; }

        public string Website { get; set; }

        public string OnePageInfo { get; set; }

        public bool IsOnePage { get; set; }

        public bool IsFilm { get; set; }

        public bool IsActive { get; set; }

        [StringLength(200)]
        public string FacebookLink { get; set; }

        [StringLength(200)]
        public string InstagramLink { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [NotMapped]
        [Required]
        public IEnumerable<int?> TagsId { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        [NotMapped]
        public IFormFile OnePagePhoto { get; set; }

        public virtual ICollection<Products> Products { get; set; }

        public virtual ICollection<Halls> Hall { get; set; }

    }
}
