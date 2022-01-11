using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentModules.Models
{
    public class calendar
    {
        [Key]
        [Required]
        public int EventId { get; set; }

        [Required]
        public int Subject { get; set; }
        public int Description { get; set; }
        [Required]
        public int Start { get; set; }
       
        public int End { get; set; }
        public int ThemeColor { get; set; }
        [Required]
        public int IsFullDay { get; set; }
        public calendar()
        {
                
        }
    }
}
