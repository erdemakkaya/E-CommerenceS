using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Categories")]
   public  class Categories:EntityBase
    {

        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Kategori Adı")]
        [MaxLength(50,ErrorMessage ="Lütfen 50 karakterden fazla veri girmeyiniz")]

        public string CategoryName { get; set; }
        [Display(Name ="Sıra")]
        public int Position { get; set; }
        public int ParentId { get; set; }
        [Display(Name ="Url")]
        public string Url { get; set; }
    }
}
