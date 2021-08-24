using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.BL.DTOs
{
   
    public class UsuariosDTO
    {
        
        public int ID_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
