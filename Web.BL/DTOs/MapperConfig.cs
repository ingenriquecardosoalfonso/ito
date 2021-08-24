using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BL.DTOs;
using Web.BL.Models;


namespace Web.BL.DTOs
{
    public class MapperConfig 
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuarios, UsuariosDTO>(); //GET
                cfg.CreateMap<UsuariosDTO, Usuarios>(); //POST - PUT

                cfg.CreateMap<Menu, MenuDTO>(); //GET
                cfg.CreateMap<MenuDTO, Menu>(); //POST - PUT
            });
        }
    }
}
