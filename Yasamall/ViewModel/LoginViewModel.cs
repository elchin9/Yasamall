using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email boş olmamalıdır"), EmailAddress(ErrorMessage ="Düzgün email daixl edin"), DataType(DataType.EmailAddress, ErrorMessage ="Düzgün email daxil edin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parol boş olmamalıdır"), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
