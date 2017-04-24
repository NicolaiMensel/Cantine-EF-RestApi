using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Contexts
{
    public class DbInit : CreateDatabaseIfNotExists<CantineContext>
    {
        protected override void Seed(CantineContext db)
        {
            List<MenuEntity> _menus = new List<MenuEntity>() { 
                #region DUMMY DATA
                new MenuEntity()
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Id = 1,
                            Name = "Tarteletter",
                            Image = ""
                        },
                        new Dish()
                        {
                            Id = 2,
                            Name = "Stegt flæsk",
                            Image = ""
                        },
                        new Dish()
                        {
                            Id = 3,
                            Name = "Råkost salat",
                            Image = ""
                        },
                        new Dish()
                        {
                            Id = 4,
                            Name = "Klar suppe med boller",
                            Image = ""
                        }
                    }
                },
                new MenuEntity()
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(4),
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Id = 5,
                            Name = "Tomat suppe",
                            Image = ""
                        },
                        new Dish()
                        {
                            Id = 6,
                            Name = "Stegt flæsk",
                            Image = ""
                        },
                        new Dish()
                        {
                            Id = 7,
                            Name = "Salat",
                            Image = ""
                        }
                    }
                }
            };

            #endregion

            foreach (var menu in _menus)
            {
                db.Menus.Add(menu);
            }
            base.Seed(db);
            
        }

    }
}