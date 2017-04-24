using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogicLayer.Entities.ViewModel;

namespace DataLogicLayer.Entities
{
    public class Dish : AbstractId
    {
        public string Name { get; set; }
        public ImageViewModel Image { get; set; }
    }
}
