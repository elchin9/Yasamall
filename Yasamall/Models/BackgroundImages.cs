using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class BackgroundImages
    {
        public int Id { get; set; }
  
        public string PhotoURLOne { get; set; }
        public string PhotoURLTwo { get; set; }
        public string PhotoURLThree { get; set; }
        public string PhotoURLFour { get; set; }
        public string PhotoURLFive { get; set; }

        [NotMapped]
        public IFormFile PhotoOne { get; set; }
        [NotMapped]
        public IFormFile PhotoTwo { get; set; }
        [NotMapped]
        public IFormFile PhotoThree { get; set; }
        [NotMapped]
        public IFormFile PhotoFour { get; set; }
        [NotMapped]
        public IFormFile PhotoFive { get; set; }
    }
}
