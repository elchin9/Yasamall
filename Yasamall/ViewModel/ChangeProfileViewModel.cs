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
    public class ChangeProfileViewModel
    {
        [Required]
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhotoURL { get; set; }

        [Required(ErrorMessage = "Telefon nömrəsi mütləq doldurulmalıdır."), StringLength(15, ErrorMessage = "Telefon nömrəsi 15 simvoldan çox ola bilməz")]
        public string Phone { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
