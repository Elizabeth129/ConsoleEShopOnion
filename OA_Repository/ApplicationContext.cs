using OA_DataAccess;
using System;
using System.Collections.Generic;

namespace OA_Repository
{
    /// <summary>
    /// Context for application
    /// </summary>
    public class ApplicationContext
    {
        /// <summary>
        /// Goods data
        /// </summary>
        public List<Goods> Goods { get; set; }
        /// <summary>
        /// Orders data
        /// </summary>
        public List<Order> Orders { get; set; }
        /// <summary>
        /// Users data
        /// </summary>
        public List<User> Users { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="goods">List of Goods</param>
        /// <param name="users">List of Users</param>
        /// <param name="orders">List of Orders</param>
        public ApplicationContext(List<Goods> goods, List<User> users, List<Order> orders)
        {
            Goods = goods;
            Users = users;
            Orders = orders;
        }
        /// <summary>
        /// Get list of Goods or Orders or Users
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <returns>List of object</returns>
        public List<object> Get<T>()
        {
            Goods goods = new Goods();
            Order order = new Order();
            User user = new User();
            if (goods is T) return Boxing(Goods);
            if (order is T) return Boxing(Users);
            if (user is T) return Boxing(Orders);
            return null;
        }
        /// <summary>
        /// Boxing type to object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="list">List for boxing</param>
        /// <returns>Boxing list of object</returns>
        private static List<object> Boxing<T>(List<T> list)
        {
            List<object> temp = new List<object>();
            foreach (var item in list)
            {
                temp.Add((object)item);
            }
            return temp;
        }
    }
}
