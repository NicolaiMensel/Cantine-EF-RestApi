using DataLogicLayer.Entities;
using DataLogicLayer.Repositories;

namespace DataLogicLayer.Factory
{
    public class Factory
    {
            private static Repository _repo;

            /// <summary>
            /// Static method enables calling the class directly instead of creating a new instance of it for access.
            /// Get existing instance or create one if it does not exist.        
            /// </summary>
            public static IRepository<MenuEntity> GetRepository
            {
                get { return _repo ?? (_repo = new Repository()); }
            }
    }
}