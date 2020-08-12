using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    /// <summary>
    /// Interface for OrderRepository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Add  new order to data
        /// </summary>
        /// <param name="order">New order</param>
        void Checkout(Order order);
        /// <summary>
        /// Change order status by id
        /// </summary>
        /// <param name="status">New order status</param>
        /// <param name="id">Order id which you want to change</param>
        void ChangeStatus(OrderStatus status, int id);
        /// <summary>
        /// Get all orders from data
        /// </summary>
        /// <returns>List of all orders</returns>
        List<Order> GetAll();
        /// <summary>
        /// Get all orders for user with such login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>List of orders</returns>
        List<Order> GetUserOders(string login);
        /// <summary>
        /// Get completed orders for user with such login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>List of completed orders</returns>
        List<Order> GetUserCompleteOders(string login);
        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Orders</returns>
        Order GetById(int id);
        /// <summary>
        /// Add new order to data
        /// </summary>
        /// <param name="item">New order</param>
        void Add(Order item);
    }
}
