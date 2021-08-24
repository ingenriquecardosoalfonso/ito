using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.BL.Data;
using Web.BL.Services.Implements;
using Web.BL.Repositories.Implements;
using System.Threading.Tasks;
using AutoMapper;
using Web.BL.Models;
using Web.BL.DTOs;

namespace Web.API.Controllers
{
    public class UsuariosController : ApiController
    {
        private IMapper mapper;
        private readonly UsuariosService UsuariosService = new UsuariosService(new UsuariosRepository(ApiContext.Create()));


        public UsuariosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        /// <summary>
        /// Metodo que permite consultar todos los Usuarios
        /// </summary>
        /// <returns>Devuelve el listado de usuarios creados</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            
            var Usuarios = await UsuariosService.GetAll();
            var usuariosDTO = Usuarios.Select(l => mapper.Map<UsuariosDTO>(l));

            return Ok(usuariosDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var Usuarios = await UsuariosService.GetById(id);
            if (Usuarios == null)
                return NotFound();

            var usuariosDTO = mapper.Map<UsuariosDTO>(Usuarios);

            return Ok(usuariosDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(UsuariosDTO usuariosDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarios = mapper.Map<Usuarios>(usuariosDTO);
                usuarios = await UsuariosService.Insert(usuarios);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }


        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(UsuariosDTO usuariosDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            usuariosDTO.ID_Usuario = id;

            var Usua = await UsuariosService.GetById(id);

            if (Usua == null)
                return NotFound();
            try
            {
                var usuarios = mapper.Map<Usuarios>(usuariosDTO);
                usuarios = await UsuariosService.Update(usuarios);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }


        }


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var Usua = await UsuariosService.GetById(id);

            if (Usua == null)
                return NotFound();
            try
            {
                
                await UsuariosService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }


        }

    }
}
