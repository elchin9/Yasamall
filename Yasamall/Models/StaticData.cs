using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class StaticData
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Xəritə ünvanı mütləq göstərilməlidir.")]
        public string Map { get; set; }

        [Required(ErrorMessage = "Facebook ünvanı mütləq göstərilməlidir."), StringLength(100)]
        public string FacebookLink { get; set; }

        [Required(ErrorMessage = "İnstagram ünvanı mütləq göstərilməlidir."), StringLength(100)]
        public string InstagramLink { get; set; }

        [Required(ErrorMessage = "Twitter ünvanı mütləq göstərilməlidir."), StringLength(100)]
        public string TwitterLink { get; set; }

        [Required(ErrorMessage = "Youtube ünvanı mütləq göstərilməlidir."), StringLength(100)]
        public string YoutubeLink { get; set; }

        [Required(ErrorMessage = "Telefon nömrəsi mütləq göstərilməlidir."), StringLength(100)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Telefon nömrəsi  mütləq göstərilməlidir."), StringLength(100)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email ünvanı mütləq göstərilməlidir."), StringLength(100)]
        public string Email { get; set; }
    }
}
