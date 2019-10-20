using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yasamall.Models
{
    public class Tags
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Tağ adı mütləq doldurulmalıdır.")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
