using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("CartProducts")]
   public class CartsProducts:EntityBase
    {
        [Key]
        public int CartProductsId { get; set; }
        public virtual Carts Cart { get; set; }
        public virtual Products Product { get; set; }

        [Required(ErrorMessage ="Adet Alanı boş geçilemez!!")]
        [Display(Name ="Adet")]
        public int  Quantity { get; set; }
  
 
        
    }
}
