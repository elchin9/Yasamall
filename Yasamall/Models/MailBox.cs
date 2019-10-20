using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class MailBox
    {
        public int  Id{ get; set; }

        [Required(ErrorMessage ="Ad bölməsi mütləq doldurulmalıdır."), StringLength(100, ErrorMessage ="Adınız 100 simvoldan çox ola bilməz.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Soyad bölməsi mütləq doldurulmalıdır."), StringLength(100, ErrorMessage = "Soyadınız 100 simvoldan çox ola bilməz.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage ="Email bölməsi mütləq doldurulmalıdır."), EmailAddress(ErrorMessage ="Düzgün email daxil edin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesaj bölməsi mütləq doldurulmalıdır.")]
        public string TextBody { get; set; }

        public DateTime Time { get; set; }
    }
}
