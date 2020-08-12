using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace OA_Repository
{
    /// <summary>
    /// Implementation of IRepository<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Application context
        /// </summary>
        private readonly ApplicationContext _context;
        /// <summary>
        /// List of Goods or User or Order 
        /// </summary>
        private readonly List<T> _list;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Application context</param>
        public Repository(ApplicationContext context)
        {
            _context = context;
            _list = Unboxing(_context.Get<T>());
        }
        /// <summary>
        /// Add new element to data
        /// </summary>
        /// <param name="elem">New element</param>
        public void Add(T elem)
        {
            _list.Add(elem);
        }
        /// <summary>
        /// Unboxing object to Goods or User or Order
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<T> Unboxing(List<object> list)
        {
            List<T> temp = new List<T>();
            foreach (var item in list)
            {
                temp.Add((T)item);
            }
            return temp;
        }
        /// <summary>
        /// Get all info from data
        /// </summary>
        /// <returns>List of info</returns>
        public List<T> GetAll()
        {
            return _list;
        }
        /// <summary>
        /// Get object by id
        /// </summary>
        /// <param name="id">Object id</param>
        /// <returns>Instance of object</returns>
        public T GetById(int id)
        {
            return _list.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
