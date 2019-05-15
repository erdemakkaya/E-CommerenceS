using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Sliders:EntityBase
    {
        [Key]
        public int SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderDesc { get; set; }
        public int Position { get; set; }
        public string SliderImageUrl { get; set; }
        public string SliderUrl { get; set; }



    }
}
