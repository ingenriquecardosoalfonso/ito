using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.BL.Models
{
    public class LMenu
    {
        [Key]
        public int Menu_ID { get; set; }
        public string Display_Name { get; set; }
        public bool Active { get; set; }
        public string Icon_Name { get; set; }
        public string Path { get; set; }
        public Nullable<int> Menu_Padre_ID { get; set; }

        public virtual List<LMenu> MenuHijo { get; set; }
    }
}
