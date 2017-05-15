using System.Collections.Generic;
using DataLogicLayer.Entities;

namespace DataLogicLayer
{
    public interface IRepository<T> where T : AbstractId
    {
        /// <summary>
        /// Get a list of all objects the Repository holds.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Get a single object, based on its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);


        /// <summary>
        /// Remove an object from the Repositorys list.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// Update/Replace objects in the Repositorys list, that have the same ID as the given object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void Update(T t);

        /// <summary>
        /// Create an object in the Repository, this allows the Repository to handle ID creation.
        /// Will also automatically call the 'Add()' method to add the object created to the Repositorys list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T Create(T t);
    }
}