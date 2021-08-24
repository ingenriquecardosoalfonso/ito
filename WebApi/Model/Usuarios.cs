using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Usuarios
    {
        [Key]
        public int ID_Usuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}
