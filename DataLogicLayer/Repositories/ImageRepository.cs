using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DataLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Repositories
{
    public class ImageRepository
    {
        public string UploadImge(string dishName, byte[] imageBytes)
        {
            var imageModel = new ImageUploadModel();
            imageModel.DishName = dishName;
            imageModel.ImageBytes = imageBytes;
            try
            {
                Account account = new Account(
                "bjoernebanden",
                "299845895553394",
                "i0N6o94uiAXrDIqu38i8KSM0q7k");

                var result = "";

                Cloudinary cloudinary = new Cloudinary(account);
                var ms = new MemoryStream(imageModel.ImageBytes);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imageModel.DishName, ms)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                result = uploadResult.Uri.ToString().Replace("\"", "");
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
