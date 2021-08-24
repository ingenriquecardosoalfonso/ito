using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.BL.Models
{
    [Table("Usuarios", Schema = "dbo")]
    public class Usuarios
    {
        [Key]
        public int ID_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
