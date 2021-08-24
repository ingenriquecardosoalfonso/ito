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
    [Route("api/menu")]
    public class MenuController : ApiController
    {
        private IMapper mapper;
        private readonly MenuService MenuService = new MenuService(new MenuRepository(ApiContext.Create()));


        public MenuController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        /// <summary>
        /// Metodo que permite consultar todos los Menus
        /// </summary>
        /// <returns>Devuelve el listado de menus creados</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            //List<Menu> ListadoMenus = Menu.ObtenerMenus();
            var menu = await MenuService.GetAll();
            var menuDTO = menu.Select(l => mapper.Map<MenuDTO>(l));

            return Ok(menuDTO);
        }

        [HttpGet]
        [Route("hijo/")]
        public async Task<IHttpActionResult> Get()
        {
            var menu = await MenuService.GetMenusAsync();
            return Ok(menu);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var Menu = await MenuService.GetById(id);
            if (Menu == null)
                return NotFound();

            var menuDTO = mapper.Map<MenuDTO>(Menu);

            return Ok(menuDTO);
        }

        /// <summary>
        /// Obtiene los menus del padre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("hijo/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            //List<Menu> ListadoMenus = Menu.ObtenerMenus();
            var menu = await MenuService.GetMenusHijosByIdAsync(id);
            var menuDTO = menu.Select(l => mapper.Map<MenuDTO>(l));

            return Ok(menuDTO);
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(MenuDTO menuDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var menu = mapper.Map<Menu>(menuDTO);
                menu = await MenuService.Insert(menu);
                return Ok(menu);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                throw;
            }


        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(MenuDTO menuDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            menuDTO.Menu_ID = id;

            var Men = await MenuService.GetById(id);

            if (Men == null)
                return NotFound();
            try
            {
                var menu = mapper.Map<Menu>(menuDTO);
                menu = await MenuService.Update(menu);
                return Ok(menu);
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
            var menu = await MenuService.GetById(id);

            if (menu == null)
                return NotFound();
            try
            {

                await MenuService.Delete(id);
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
