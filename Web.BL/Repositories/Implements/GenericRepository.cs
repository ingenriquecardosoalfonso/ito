using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Web.BL.Data;
using Web.BL.Models;

namespace Web.BL.Repositories.Implements
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApiContext apiContext;

        public GenericRepository(ApiContext ApiContext)
        {
            this.apiContext = ApiContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            apiContext.Set<TEntity>().Remove(entity);
            await apiContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await apiContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await apiContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<Menu>> GetMenusHijosByIdAsync(int id)
        {
            var menu = await apiContext.Menu.Where(l => l.Menu_Padre_ID == id).ToListAsync(); 
            return menu;
        }

        public async Task<IEnumerable<LMenu>> GetMenusAsync()
        {
            List<LMenu> Listado = new List<LMenu>();
            List<Menu> ListadoTotal = await apiContext.Menu.ToListAsync();
            List<Menu> ListadoMenus = await apiContext.Menu.Where(l => l.Menu_Padre_ID == 0).ToListAsync();
            
            foreach (Menu padre in ListadoMenus)
            {
                LMenu NMenu = RetornarMenu(padre);
                NMenu = ObtenerHijos(NMenu, ListadoTotal);
                Listado.Add(NMenu);

                
            }


            return Listado;
        }

        private LMenu RetornarMenu(Menu menu)
        {
            LMenu Lmenu = new LMenu
            {
                Menu_ID = menu.Menu_ID,
                Display_Name = menu.Display_Name,
                Active = menu.Active,
                Icon_Name = menu.Icon_Name,
                Path = menu.Path,
                Menu_Padre_ID = menu.Menu_Padre_ID
            };
            return Lmenu;
        }

        private LMenu ObtenerHijos(LMenu padre, List<Menu> Total )
        {
            List<Menu> Hijos = Total.Where(l => l.Menu_Padre_ID == padre.Menu_ID).ToList();
            LMenu RespuestaMenu = new LMenu();
            padre.MenuHijo = new List<LMenu>();
            foreach (Menu Hijo in Hijos)
            {
                LMenu NMenu = RetornarMenu(Hijo);
                RespuestaMenu = ObtenerHijos(NMenu, Total);
                if(RespuestaMenu.Menu_ID==0)
                    padre.MenuHijo.Add(NMenu);
                else
                    padre.MenuHijo.Add(RespuestaMenu);
            }

            return padre;

        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            apiContext.Set<TEntity>().Add(entity);
            await apiContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //apiContext.Entry(entity).State = EntityState.Modified;
            apiContext.Set<TEntity>().AddOrUpdate(entity);
            await apiContext.SaveChangesAsync();
            return entity;
        }
    }
}
