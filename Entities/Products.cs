using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Products")]
    public class Products:EntityBase
    {

        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ad Soyad alanı boş geçilemez!!")]
        [MaxLength(100, ErrorMessage = "Lütfen 100 karakterden fazla değer girmeyiniz")]
        public string ProductName { get; set; }
        [Display(Name = "Tutar")]
        [DataType(DataType.Currency)]
     
        public  double ProductPrice { get; set; }
        [Display(Name ="Ürün Açıklaması")]


        public string ProductDesc { get; set; }
        [Display(Name = "Stok")]
       

        public int ProductStock { get; set; }
        
        [Display(Name ="Image url")]

        public string ProductImage  { get; set; }
        [Display(Name = "İndirim")]
        [DataType(DataType.Currency)]

        public double Discount { get; set; }
        public  Categories ProductCategory { get; set; }

        




    }
}