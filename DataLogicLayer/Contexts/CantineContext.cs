using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataLogicLayer.Entities;

namespace DataLogicLayer.Contexts
{
    public class CantineContext : DbContext
    {
        public CantineContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DbInit());
        }

        public virtual DbSet<MenuEntity> Menus { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent-api
            modelBuilder.Entity<MenuEntity>().HasMany<Dish>(d => d.Dishes);
            base.OnModelCreating(modelBuilder);
        }
    }
}