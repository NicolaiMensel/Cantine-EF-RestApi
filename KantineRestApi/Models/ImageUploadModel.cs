using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KantineRestApi.Models
{
    public class ImageUploadModel
    {
        public string DishName { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}