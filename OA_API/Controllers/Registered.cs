using OA_DataAccess;
using OA_Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OA_API.Controllers
{
    /// <summary>
    /// Class for user with type Registered
    /// </summary>
    public class Registered
    {
        /// <summary>
        /// User with type Administrator
        /// </summary>
        public User user;
        /// <summary>
        /// Repository for goods
        /// </summary>
        private readonly IGoodsRepository goods;
        /// <summary>
        /// Repository for users
        /// </summary>
        private readonly IUserRepository users;
        /// <summary>
        /// Repository for orders
        /// </summary>
        private readonly IOrderRepository orders;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orders">Repository for orders</param>
        /// <param name="goods">Repository for goods</param>
        /// <param name="users">Repository for users</param>
        public Registered(IOrderRepository orders, IGoodsRepository goods, IUserRepository users)
        {
            this.users = users;
            this.goods = goods;
            this.orders = orders;
        }
        /// <summary>
        /// Get list of all goods in data
        /// </summary>
        /// <returns>List of all goods</returns>
        public  List<Goods> ViewAllGoods()
        {
            return goods.GetAll();
        }
        /// <summary>
        /// Get list of goods which have such name
        /// </summary>
        /// <param name="name">Name of goods</param>
        /// <returns>List of goods with such name</returns>
        public  List<Goods> SearchByName(string name)
        {
            return goods.GetGoodsByName(name);
        }
        /// <summary>
        /// Add goods to basket to create new order
        /// </summary>
        /// <param name="goods">Good what you want to buy</param>
        public void AddToBasket(Goods goods)
        {
            user.Basket.Add(goods);
        }
        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="customerName">Name of customer</param>
        /// <param name="customerPhoneNumber">Customer Phone</param>
        /// <param name="deliveryAddress">Delivery adress</param>
        public void Checkout(string customerName, string customerPhoneNumber, string deliveryAddress)
        {
            if (user.Basket.Count == 0) throw new ArgumentException("Basket is empty");
            Order order = new Order(user.Login, customerName, customerPhoneNumber, deliveryAddress, user.Basket);
            orders.Checkout(order);
            user.Basket = new List<Goods>();
        }
        /// <summary>
        /// Deny order by ID
        /// </summary>
        /// <param name="id">Id of order which you want to deny</param>
        /// <returns>True if order was deny, or false if its immposible</returns>
        public  bool DenyOrder(int id)
        {
            if (orders.GetAll().Where(o => o.Id == id).Select(o => o).Count() > 0)
            {
                if (orders.GetAll().Where(o => o.Id == id).Select(o => o.orderStatus).FirstOrDefault() != OrderStatus.Completed)
                {
                    orders.ChangeStatus(OrderStatus.CanceledByUser, id);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get all orders for this user
        /// </summary>
        /// <returns>List of orders</returns>
        public  List<Order> UserOrders()
        {
            return orders.GetUserOders(user.Login);
        }
        /// <summary>
        /// Get completed orders for this user
        /// </summary>
        /// <returns>List of orders</returns>
        public  List<Order> UserCompleteOrders()
        {
            return orders.GetUserCompleteOders(user.Login);
        }
        /// <summary>
        /// Change order status by ID
        /// </summary>
        /// <param name="id">Order id which you want to change</param>
        public  void ChangeStatusToComplete(int id)
        {
            if (orders.GetAll().Where(o => o.Id == id).Select(o => o).Count() > 0)
                orders.ChangeStatus(OrderStatus.Completed, id);
        }
        /// <summary>
        /// Change this user profile
        /// </summary>
        /// <param name="temp">New information</param>
        public  void ChangeProfile(User temp)
        {
            users.ChangePersonalInformation(user, temp);
        }
       
    }
}
