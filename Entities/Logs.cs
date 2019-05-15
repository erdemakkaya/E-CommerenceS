using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Logs")]
    public class Logs 
    {

        [Key]
        public int LogId { get; set; }
        [Required, StringLength(55), DisplayName("Kullanıcı Adı")]
        public string LogUserName { get; set; }
        [StringLength(100), DisplayName("Controller")]
        public string ControllerName { get; set; }
        [StringLength(500), DisplayName("Bilgi")]
        public string LogInfo { get; set; }
        [Required, DisplayName("işlem Tarihi")]
        public DateTime LogCreationDate { get; set; }
       [StringLength(100),DisplayName("Action")]
        public string ActionName { get; set; }

        [StringLength(25),DisplayName("IP")]
        public string IpAddress { get; set; }
        [DisplayName("Log")]
        public int Type { get; set; }


    }
}
