using System;
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
        /*CREATE*/
        public MenuEntity Create(MenuEntity t)
        {
            using (var db = new CantineContext())
            {
                db.Menus.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        /*READ BY ID*/
        public MenuEntity Get(int id)
        {
            using (var db = new CantineContext())
            {
                return db.Menus.Include("Dishes").FirstOrDefault(x => x.Id == id);
            }
        }

        /*READ ALL*/
        public List<MenuEntity> GetAll()
        {
            using (var db = new CantineContext())
            {
                return db.Menus.Include("Dishes").ToList();
            }
        }

        /*UPDATE*/
        public void Update(MenuEntity t)
        {
            List<int> dishesToDelete = new List<int>();
            using (var db = new CantineContext())
            {
                var menuToUpdate = db.Menus.Include("Dishes").FirstOrDefault(x => x.Id == t.Id);
                foreach (var dish in menuToUpdate.Dishes)
                {
                    if (t.Dishes.FirstOrDefault(x => x.Id == dish.Id) == null)
                    {
                        dishesToDelete.Add(dish.Id.Value);
                    }
                }
                foreach (var id in dishesToDelete)
                {
                    db.Entry(menuToUpdate.Dishes.FirstOrDefault(x => x.Id == id)).State = EntityState.Deleted;
                }
                foreach (var dish in t.Dishes)
                {
                    if (dish.Id.HasValue)
                    {
                        var dishToUpdate = menuToUpdate.Dishes.FirstOrDefault(x => x.Id == dish.Id);

                        dishToUpdate.Image = dish.Image;
                        dishToUpdate.Name = dish.Name;
                        db.Entry(dishToUpdate).State = EntityState.Modified;
                    }
                    else
                    {
                        menuToUpdate.Dishes.Add(dish);
                    }
                }
                db.SaveChanges();
            }
        }

        /*DELETE*/
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
    }
}