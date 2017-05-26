using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Contexts
{
    public class DbInit : DropCreateDatabaseAlways<CantineContext>
    //public class DbInit : CreateDatabaseIfNotExists<CantineContext>
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
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482165/24556159-tarteletter_iux6to.jpg"
                        },
                        new Dish()
                        {
                            Id = 2,
                            Name = "Stegt flæsk",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820289/stegtfl%C3%A6sk_rbt7bu.jpg"
                        },
                        new Dish()
                        {
                            Id = 3,
                             Name = "Tomatsalat",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820290/mixedsalat_ovekxf.jpg"
                        },
                        new Dish()
                        {
                            Id = 4,
                            Name = "Minestronesuppe",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820289/minestrone_lfb5da.jpg"
                        }
                    }
                },
                new MenuEntity()
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(1),
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Id = 5,
                            Name = "Tomatsuppe",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820290/tomatsuppe_mxmihk.png"
                        },
                        new Dish()
                        {
                            Id = 6,
                            Name = "Flæskesteg",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820289/fl%C3%A6skesteg_uqjyip.jpg"
                        },
                        new Dish()
                        {
                            Id = 7,
                            Name = "Frikadeller",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820290/frikadeller_ko7rlj.jpg"
                        },
                        new Dish()
                        {
                            Id = 8,
                            Name = "Pastasalat",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820291/pastasalat_oslbhf.jpg"
                        },
                        new Dish()
                        {
                            Id = 9,
                            Name = "Frisk grøn salat",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1495820289/salat_h0stfe.jpg"
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