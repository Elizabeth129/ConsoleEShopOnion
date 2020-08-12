using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    /// <summary>
    /// Interface for GoodsRepository
    /// </summary>
    public interface IGoodsRepository
    {
        /// <summary>
        /// Get all goods from data
        /// </summary>
        /// <returns>List of all goods</returns>
        List<Goods> GetAll();
        /// <summary>
        /// Get goods by name from data
        /// </summary>
        /// <param name="name">Name of goods</param>
        /// <returns>List of goods with such name</returns>
        List<Goods> GetGoodsByName(string name);
        /// <summary>
        /// Add new good to data
        /// </summary>
        /// <param name="goods">New good</param>
        void Add(Goods goods);
        /// <summary>
        /// Change good information
        /// </summary>
        /// <param name="goods">New information</param>
        /// <param name="id">Goods Id which you want to change</param>
        void Change(Goods goods, int id);
        /// <summary>
        /// Get good by id
        /// </summary>
        /// <param name="id">Goods id</param>
        /// <returns>Goods</returns>
        Goods GetById(int id);
    }
}
