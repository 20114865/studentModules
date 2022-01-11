using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentModules.Models
{
    public class study
    {
        [Key]
        [Required]
        [DisplayName("Module Code")]
        public string ModuleCode { get; set; }
        [Required]
        public int HoursSpecificModule { get; set; }
        [DisplayName("Today Date")]
        [Required]
        public string TodayDate { get; set; }
        
        
    }
}
