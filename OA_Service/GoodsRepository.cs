using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OA_Service
{
    /// <summary>
    /// Class to implement IGoodsRepository
    /// </summary>
    public class GoodsRepository : IGoodsRepository
    {
        /// <summary>
        /// Id of good
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Repository of goods
        /// </summary>
        private IRepository<Goods> _repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Repository of goods</param>
        public GoodsRepository(IRepository<Goods> repository)
        {
            Id = 0;
            _repository = repository;
        }
        /// <summary>
        /// Add new good to data
        /// </summary>
        /// <param name="goods">New good</param>
        public void Add(Goods goods)
        {
            goods.Id = Id;
            Id++;
            _repository.Add(goods);
        }
        /// <summary>
        /// Change good information
        /// </summary>
        /// <param name="goods">New information</param>
        /// <param name="id">Goods Id which you want to change</param>
        public void Change(Goods goods, int id)
        {
            Goods g = _repository.GetAll().Where(g => g.Id.Equals(id)).Select(g => g).FirstOrDefault();
            if (goods.Description != null) g.Description = goods.Description;
            if (goods.Name != null) g.Name = goods.Name;
            if (goods.Price > 0) g.Price = goods.Price;
        }
        /// <summary>
        /// Get all goods from data
        /// </summary>
        /// <returns>List of all goods</returns>
        public List<Goods> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Get good by id
        /// </summary>
        /// <param name="id">Goods id</param>
        /// <returns>Goods</returns>
        public Goods GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Get goods by name from data
        /// </summary>
        /// <param name="name">Name of goods</param>
        /// <returns>List of goods with such name</returns>
        public List<Goods> GetGoodsByName(string name)
        {
            var goods = _repository.GetAll().Where(g => g.Name.Equals(name)).Select(g => g).ToList();
            return goods;
        }
    }
}
