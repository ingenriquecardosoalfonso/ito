using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BL.Data;

namespace Web.BL.Models
{

    [Table("Menu", Schema = "dbo")]
    [Serializable]
    public class Menu
    {
        [Key]
        public int Menu_ID { get; set; }
        public string Display_Name { get; set; }
        public bool Active { get; set; }
        public string Icon_Name { get; set; }
        public string Path { get; set; }
        public Nullable<int> Menu_Padre_ID { get; set; }


    }

}
