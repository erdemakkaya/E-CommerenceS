using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

[Table("Carts")]
 public   class Carts:EntityBase
    {
        [Key]
        public int CartId { get; set; }
        [Required]

       
        public bool IsPaid {get; set;}
  
        public virtual ICollection<CartsProducts> CartsProduct { get; set; }
        public virtual Users user { get; set; }
      
     




    }
}
