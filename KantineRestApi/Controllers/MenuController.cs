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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Web.Http.Cors;
using KantineRestApi.Models;
using DataLogicLayer.Repositories;

namespace KantineRestApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")] // For JS web app.
    public class MenuController : ApiController
    {
        private readonly IRepository<MenuEntity> _menuRep = Factory.GetRepository;
        private readonly ImageRepository _imgRepo = Factory.GetImageRepository;

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
            return CreatedAtRoute("DefaultApi", new { id = menu.Id }, menu);
        }

        [HttpPut]
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
        [HttpDelete]
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

        [Route("api/Menu/UploadImage")]
        [HttpPost]
        public IHttpActionResult UploadImage(ImageUploadModel image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_imgRepo.UploadImge(image.DishName, image.ImageBytes));
        }

        /// <summary>
        /// Returns a list of URL's of all images.
        /// </summary>
        /// <returns></returns>
        // GET: api/Menu/GetAllImages
        [Route("api/Menu/GetAllImages")]
        [HttpGet]
        public List<string> GetAllImages()
        {
            var allImages = _menuRep.GetAll()
                .SelectMany(x => x.Dishes)
                .OrderBy(x => x.Name)
                .GroupBy(x => x.Image)
                .Select(x => x.FirstOrDefault().Image).ToList();
            return allImages;
        }
    }
}
