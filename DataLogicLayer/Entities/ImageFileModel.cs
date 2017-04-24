using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogicLayer.Entities
{
    public class ImageFileModel : AbstractId
    {
        public string Title { get; set; }
        public byte[] File { get; set; }
    }
}
