using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OA_Service
{
    /// <summary>
    /// Class to implement IOrderRepository
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Id of order
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Repository of orders
        /// </summary>
        private IRepository<Order> _repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Repository of orders</param>
        public OrderRepository(IRepository<Order> repository)
        {
            Id = 0;
            _repository = repository;
        }
        /// <summary>
        /// Add new order to data
        /// </summary>
        /// <param name="item">New order</param>
        public void Add(Order item)
        {
            item.Id = Id;
            Id++;
            _repository.Add(item);
        }
        /// <summary>
        /// Change order status by id
        /// </summary>
        /// <param name="status">New order status</param>
        /// <param name="id">Order id which you want to change</param>
        public void ChangeStatus(OrderStatus status, int id)
        {
            Order order =_repository.GetAll().Where(o => o.Id == id).Select(o => o).FirstOrDefault();
            order.orderStatus = status;
        }
        /// <summary>
        /// Add  new order to data
        /// </summary>
        /// <param name="order">New order</param>
        public void Checkout(Order order)
        {
            this.Add(order);
        }
        /// <summary>
        /// Get all orders from data
        /// </summary>
        /// <returns>List of all orders</returns>
        public List<Order> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Orders</returns>
        public Order GetById(int id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Get completed orders for user with such login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>List of completed orders</returns>
        public List<Order> GetUserCompleteOders(string login)
        {
            return _repository.GetAll().Where(o => (o.CustomerLogin == login && o.orderStatus == OrderStatus.Completed)).Select(o => o).ToList();
        }
        /// <summary>
        /// Get all orders for user with such login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>List of orders</returns>
        public List<Order> GetUserOders(string login)
        {
            return _repository.GetAll().Where(o => o.CustomerLogin == login).Select(o => o).ToList();
        }
    }
}
