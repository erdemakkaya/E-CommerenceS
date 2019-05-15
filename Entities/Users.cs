using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "E-Posta")]
        [Required]
        [EmailAddress]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string UserEmail { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(20, ErrorMessage = "Lütfen 20 karakterden fazla değer girmeyiniz")]

        public string UserPassword { get; set; }
        [Display(Name = "Adres")]
        [Required]
        [MaxLength(250, ErrorMessage = " Lütfen 250 karakterden fazla değer girmeyiniz.")]
        public string UserAdress { get; set; }
        [Required(ErrorMessage = "Telefon Numarası Boş geçilemez")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Lütfen var olan bir telefon numarası giriniz")]
        public string Phone { get; set; }
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez!!")]
        [MaxLength(100, ErrorMessage = "Lütfen 100 karakterden fazla değer girmeyiniz")]
       
        public string UserName { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }

    }
}
