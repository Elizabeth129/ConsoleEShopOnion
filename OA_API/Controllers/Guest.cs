using System;
using System.Collections.Generic;
using System.Text;
using OA_DataAccess;
using OA_Service;
using System.Linq;

namespace OA_API.Controllers
{
    /// <summary>
    /// Class for Guest
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// User with type Guest
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
        /// Constructor
        /// </summary>
        /// <param name="orders">Repository for orders</param>
        /// <param name="goods">Repository for goods</param>
        /// <param name="users">Repository for users</param>
        public Guest(IOrderRepository orders, IGoodsRepository goods, IUserRepository users)
        {
            this.users = users;
            this.goods = goods;
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
        /// Register new account for user
        /// </summary>
        /// <param name="user">New user</param>
        public  void Register(User user)
        {
            users.Add(user);
        }
        /// <summary>
        /// Log in to account
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>Instance of user</returns>
        public User LogIn(string login, string password)
        {
            if (users.GetAll().Where(a => (a.Login == login) && (a.Password == password)).Count() < 1)
                throw new ArgumentException("Wrong Log In");
            else
            {
                Console.WriteLine("Authorized!");
                return users.GetAll().Where(a => (a.Login == login) && (a.Password == password)).FirstOrDefault();
            }
        }
        /// <summary>
        /// Check user login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>False if this login exist in data already, else true</returns>
        public  bool CheckLogin(string login)
        {
            if (users.GetAll().Where(u => u.Login.Equals(login)).Select(u => u).Count() > 0 || login.Length == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check correct login and password to LogIn
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <returns>False if login or password wrong</returns>
        public  bool CheckForLogIn(string login, string password)
        {
            if (users.GetAll().Where(a => (a.Login == login) && (a.Password == password)).Count() < 1)
            {
                return false;
            }
            return true;
        }
    }
}
