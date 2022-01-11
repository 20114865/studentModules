using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentModules.Models
{
    public class modules
    {
        [Key]
        [Required]
        [DisplayName("Module Code")]
        public string ModuleCode { get; set; }
        [Required]
        [DisplayName("Module")]
        public string Module { get; set; }
        [Required]
        [DisplayName("Number Of Credits")]
        public int NumberOfCredits { get; set; }
        [Required]
        [DisplayName("Class Hours Per Week")]
        public int ClassHoursPerWeek { get; set; }
        [Required]
        [DisplayName(" Number Of Weeks")]
        public int NumberOfWeeks { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public string StartDate { get; set; }
        [DisplayName("Self Study Hours Per Week")]
        
        public int SelfStudyHoursPerWeek { get; set; }
   
        [DisplayName("Self study Remains week")]
        public int SelfstudyRemainsweek { get; set; }


    }
}
