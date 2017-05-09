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

namespace KantineRestApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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

        /// <summary>
        /// Returns a list of URL's of all images.
        /// </summary>
        /// <returns></returns>
        // GET: api/Menu/GetAllImages
        [Route("api/Menu/GetAllImages")]
        [HttpGet]
        public List<string> GetAllImages()
        {
            var allImages = _menuRep.GetAll().SelectMany(x => x.Dishes).OrderBy(x => x.Name).GroupBy(x => x.Image).Select(x => x.FirstOrDefault().Image).ToList();
            return allImages;
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
            try
            {
                Account account = new Account(
      "bjoernebanden",
      "299845895553394",
      "i0N6o94uiAXrDIqu38i8KSM0q7k");

                var result = "";

                Cloudinary cloudinary = new Cloudinary(account);
                var ms = new MemoryStream(image.ImageBytes);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.DishName, ms)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                result = uploadResult.Uri.ToString().Replace("\"", "");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        public class ImageUploadModel
        {
            public string DishName { get; set; }
            public byte[] ImageBytes { get; set; }
        }

        public HttpResponseMessage OptionsMenu()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }

    }
}
