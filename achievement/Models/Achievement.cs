using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace achievement.Models
{
    public class Achievement
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Achiever's Name")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Name")]
        public String Name { get; set; }
        [Url]
        [Display(Name = "Youtube URL")]
        [RegularExpression("^(https://www.youtube.com/)", ErrorMessage = "Youtube Url only")]
        public String URL { get; set; }
        [Required]
        [StringLength(10000)]
        public String Acheivement { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }

    }
}