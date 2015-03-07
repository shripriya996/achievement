using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace achievement.Models
{
    public class Achievement
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Acheivement { get; set; }
        public DateTime Created { get; set; }
        public string Createdby { get; set; }

    }
}