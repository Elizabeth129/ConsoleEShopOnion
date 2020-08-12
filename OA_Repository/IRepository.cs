using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository
{
    /// <summary>
    /// Interface of repository
    /// </summary>
    /// <typeparam name="T">Goods or User or Order</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all info from data
        /// </summary>
        /// <returns>List of info</returns>
        List<T> GetAll();
        /// <summary>
        /// Get object by id
        /// </summary>
        /// <param name="id">Object id</param>
        /// <returns>Instance of object</returns>
        T GetById(int id);
        /// <summary>
        /// Add new element to data
        /// </summary>
        /// <param name="elem">New element</param>
        void Add(T elem);

    }
}
