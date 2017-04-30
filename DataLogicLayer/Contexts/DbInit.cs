using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Contexts
{
    //public class DbInit : DropCreateDatabaseAlways<CantineContext>
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
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482165/24556159-tarteletter_iux6to.jpg"
                        },
                        new Dish()
                        {
                            Id = 2,
                            Name = "Stegt flæsk",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482190/restaurant-bennys-aarhus-080515-2221262-regular_mmb71l.jpg"
                        },
                        new Dish()
                        {
                            Id = 3,
                            Name = "Råkost salat",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493487117/ra_CC_8Akost-med-spidska_CC_8Al-og-guler_C3_B8dder_lyyrhu.jpg"
                        },
                        new Dish()
                        {
                            Id = 4,
                            Name = "Klar suppe med boller",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482217/klar-suppe-med-k_C3_B8d-og-melboller-23_tajljq.jpg"
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
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482114/582239-960x720-tomatensuppe_vobtvc.jpg"
                        },
                        new Dish()
                        {
                            Id = 6,
                            Name = "Flæskesteg",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482083/Flaeskesteg-af-svinekam-med-sproed-svaer-og-traditionelt-tilbehoer-2_b7g3ft.jpg"
                        },
                        new Dish()
                        {
                            Id = 7,
                            Name = "Salat",
                            Image = "http://res.cloudinary.com/bjoernebanden/image/upload/v1493482436/opskrift-in-modemagasinet-in-sommersalat-foraarssalat_v9eqvu.jpg"
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