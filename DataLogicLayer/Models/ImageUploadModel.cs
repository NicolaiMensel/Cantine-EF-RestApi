using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Models
{
    public class ImageUploadModel
    {
        public string DishName { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
