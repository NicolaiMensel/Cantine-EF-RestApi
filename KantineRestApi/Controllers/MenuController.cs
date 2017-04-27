using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLogicLayer;
using DataLogicLayer.Entities;
using DataLogicLayer.Factory;

namespace KantineRestApi.Controllers
{
    public class MenuController : ApiController
    {
        private readonly IRepository<MenuEntity> _menuRep = Factory.GetRepository;
        // GET: api/Menu
        public List<MenuEntity> Get()
        {
            return _menuRep.GetAll();
        }

        // GET: api/Menu/5
        public IHttpActionResult Get(int id)
        {
            MenuEntity menu = _menuRep.Get(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        // POST: api/Menu
        public IHttpActionResult Post(MenuEntity menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _menuRep.Create(menu);
            return CreatedAtRoute("DefaultApi", new {id = menu.Id }, menu);
        }

        // PUT: api/Menu/5
        public IHttpActionResult Put(int id, MenuEntity menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.Id)
            {
                return BadRequest(ModelState);
            }
            _menuRep.Update(menu);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Menu/5
        public IHttpActionResult Delete(int id)
        {
            MenuEntity menu = _menuRep.Get(id);
            if (menu == null)
            {
                return NotFound();
            }
            _menuRep.Delete(menu);
            return Ok(menu);
        }

    }
}
