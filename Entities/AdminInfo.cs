using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("AdminInfo")]
   public class AdminInfo:EntityBase
    {
        [Key]
        public int AdminInfoId { get; set; }
        [Display(Name = "AdminId")]


        public string UserName { get; set; }
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez!!")]
        [MaxLength(100, ErrorMessage = "Lütfen 100 karakterden fazla değer girmeyiniz")]
        public string AdminName { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(20, ErrorMessage = "Lütfen 20 karakterden fazla değer girmeyiniz")]
        public string AdminPw { get; set;  }
    }
}
