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
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Name")]
        public String Name { get; set; }
        [Url]
        [Display(Description = "Youtube URL")]
        [RegularExpression("^(https://www.youtube.com/)", ErrorMessage = "Only Youtube Url")]
        public String URL { get; set; }
        [Required]
        [StringLength(10000)]
        public String Acheivement { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }

    }
}