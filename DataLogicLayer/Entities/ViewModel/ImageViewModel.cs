using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLogicLayer.Entities.ViewModel
{
    public class ImageViewModel
    {
        public string Title { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}
