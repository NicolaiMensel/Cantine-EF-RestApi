using System;
using System.Collections.Generic;

namespace DataLogicLayer.Entities
{
    public class MenuEntity : AbstractId
    {
        public DateTime Date { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}