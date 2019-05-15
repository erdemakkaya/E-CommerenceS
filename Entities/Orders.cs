using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Order")]
       public class Orders:EntityBase
    {

        [Key]
     

        public int OrdderId { get; set; }
        [Display(Name ="Tutar")]
        [DataType(DataType.Currency)]
        public double OrdderAmount { get; set; }
        [Display(Name = "Adres")]
        [MaxLength(500,ErrorMessage ="harf sınırı aşılmıştır lütfen 500 kelieden az harf kullanın")]
        [Required]
        public string OrderAdress { get; set; }

        [Display(Name = "E-Posta")]
        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string OrderMail { get; set; }

        [Display(Name = "Gönderen Adı")]
        public string OrderShipName { get; set; }

        public string isOrderShipped { get; set; }
        [Required]
      
        public virtual Carts Cart { get; set; }

        public virtual Users User { get; set; }
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez!!")]
        [MaxLength(100, ErrorMessage = "Lütfen 100 karakterden fazla değer girmeyiniz")]
        public string UserName { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Lütfen var olan bir telefon numarası giriniz")]
        public string UserTel { get; set; }
       [MaxLength(250,ErrorMessage = "250 harf sınırı aşılamaz")]
        public string  OrderDetail { get; set;  }






    }
}
