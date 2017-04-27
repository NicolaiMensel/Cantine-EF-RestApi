using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using DataLogicLayer.Contexts;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Repositories
{
    public class Repository : IRepository<MenuEntity>
    {
        public List<MenuEntity> GetAll()
        {
            using (var db = new CantineContext())
            {
                return db.Menus.Include("Dishes").ToList();
            }
        }

        public MenuEntity Get(int id)
        {
            using (var db = new CantineContext())
            {
                return db.Menus.Include("Dishes").FirstOrDefault(x => x.Id == id);
            }
        }

        public bool Delete(MenuEntity t)
        {
            using (var db = new CantineContext())
            {
                MenuEntity menu = db.Menus.Include("Dishes").FirstOrDefault(x => x.Id == t.Id);
                foreach (var dish in menu.Dishes.ToList())
                {
                    db.Entry(dish).State = EntityState.Deleted;
                }
                db.Entry(menu).State = EntityState.Deleted;
                db.SaveChanges();
                return db.Menus.FirstOrDefault(x => x.Id == t.Id) == null;
            }
        }

        public MenuEntity Update(MenuEntity t)
        {
            using (var db = new CantineContext())
            {
                var menuToUpdate = db.Menus.Include("Dishes").FirstOrDefault(x => x.Id == t.Id);
                if (menuToUpdate != null)
                {
                    menuToUpdate.Dishes = t.Dishes;
                    menuToUpdate.Date = t.Date;
                }
                db.SaveChanges();
                return db.Menus.Include("Dishes").FirstOrDefault(x => x.Id == t.Id);
            }
        }

        public MenuEntity Create(MenuEntity t)
        {
            using (var db = new CantineContext())
            {
                db.Menus.Add(t);
                db.SaveChanges();
                return t;
            }
        }
    }
}