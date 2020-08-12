using NUnit.Framework;
using OA_API.Controllers;
using OA_DataAccess;
using OA_Repository;
using OA_Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ViewAllGoods_Guest_ListOfGoods()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            goods.Add(new Goods("Name2", "Descr2", 16m));
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m) };
            Guest guest = new Guest(orders, goods, users);
            Goods[] actual = guest.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "View goods work incorrectry.");
        }
        [Test]
        public void ViewAllGoods_Registered_ListOfGoods()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            goods.Add(new Goods("Name2", "Descr2", 16m));
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m) };
            Registered registered = new Registered(orders, goods, users);
            Goods[] actual = registered.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "View goods work incorrectry.");
        }
        [Test]
        public void ViewAllGoods_Admin_ListOfGoods()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            goods.Add(new Goods("Name2", "Descr2", 16m));
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m) };
            Admin admin = new Admin(orders, goods, users);
            Goods[] actual = admin.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "View goods work incorrectry.");
        }
        [Test]
        public void SearchByName_Guest_ListOfGoods()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            goods.Add(new Goods("Name2", "Descr2", 16m));
            goods.Add(new Goods("Name2", "Descr3", 18m));
            Guest guest = new Guest(orders, goods, users);
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m), new Goods("Name2", "Descr3", 18m) };
            Goods[] actual = guest.SearchByName("Name2").ToArray();
            Assert.AreEqual(expected, actual, message: "SearchByName work incorrectry.");
        }
        [Test]
        public void SearchByName_Registered_ListOfGoods()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            goods.Add(new Goods("Name2", "Descr2", 16m));
            goods.Add(new Goods("Name2", "Descr3", 18m));
            Registered registered = new Registered(orders, goods, users);
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m), new Goods("Name2", "Descr3", 18m) };
            Goods[] actual = registered.SearchByName("Name2").ToArray();
            Assert.AreEqual(expected, actual, message: "SearchByName work incorrectry.");
        }
        [Test]
        public void SearchByName_Admin_ListOfGoods()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            goods.Add(new Goods("Name2", "Descr2", 16m));
            goods.Add(new Goods("Name2", "Descr3", 18m));
            Admin admin = new Admin(orders, goods, users);
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m), new Goods("Name2", "Descr3", 18m) };
            Goods[] actual = admin.SearchByName("Name2").ToArray();
            Assert.AreEqual(expected, actual, message: "SearchByName work incorrectry.");
        }
        [Test]
        public void Registration_AddUser_UserAdded()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Guest guest = new Guest(orders, goods, users);
            guest.Register(new User("Loginnn", "password"));
            User[] expected = new User[] {  new User("Loginnn", "password", UserType.Registered) };
            User[] actual = users.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "Registration user work incorrectly");
        }
        [Test]
        public void CreateNewOrderUser_Goods_AddToBasket()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            registered.user = user;
            registered.AddToBasket(good);
            Goods[] expected = new Goods[] { new Goods("goods", "desc", 10m) };
            Goods[] actual = registered.user.Basket.ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void CreateNewOrderAdmin_Goods_AddToBasket()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            admin.user = user;
            admin.AddToBasket(good);
            Goods[] expected = new Goods[] { new Goods("goods", "desc", 10m) };
            Goods[] actual = admin.user.Basket.ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void CheckoutByUser_Basket_NewOrder()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            registered.user = user;
            registered.AddToBasket(good);
            registered.Checkout("name", "34234", "sdsas");
            Order[] expected = new Order[] { new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList()) };
            Order[] actual = orders.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void CheckoutByAdmin_Basket_NewOrder()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            admin.user = user;
            admin.AddToBasket(good);
            admin.Checkout("name", "34234", "sdsas");
            Order[] expected = new Order[] { new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList()) };
            Order[] actual = orders.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void DenyOrderUser_NewOrder_DenyOrder()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            registered.user = user;
            registered.AddToBasket(good);
            registered.Checkout("name", "34234", "sdsas");
            Order order = orders.GetAll().FirstOrDefault();
            registered.DenyOrder(order.Id);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.CanceledByUser;
            Order[] expected = new Order[] { order1 }; 
            Order[] actual = orders.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void DenyOrderAdmin_NewOrder_DenyOrder()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            admin.user = user;
            admin.AddToBasket(good);
            admin.Checkout("name", "34234", "sdsas");
            Order order = orders.GetAll().FirstOrDefault();
            admin.DenyOrder(order.Id);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.CanceledByAdministrator;
            Order[] expected = new Order[] { order1 };
            Order[] actual = orders.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void ChangeStatusToComplete_Order_ChangeStatusOrder()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            registered.user = user;
            registered.AddToBasket(good);
            registered.Checkout("name", "34234", "sdsas");
            Order order = orders.GetAll().FirstOrDefault();
            registered.ChangeStatusToComplete(order.Id);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.Completed;
            Order[] expected = new Order[] { order1 };
            Order[] actual = orders.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void ChangeStatusAdmin_Order_ChangeStatusOrder()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            admin.user = user;
            admin.AddToBasket(good);
            admin.Checkout("name", "34234", "sdsas");
            Order order = orders.GetAll().FirstOrDefault();
            admin.ChangeStatus(order.Id, OrderStatus.Received);
            Order order1 = new Order("log", "name", "34234", "sdsas", (new Goods[] { new Goods("goods", "desc", 10m) }).ToList());
            order1.orderStatus = OrderStatus.Received;
            Order[] expected = new Order[] { order1 };
            Order[] actual = orders.GetAll().ToArray();
            Assert.AreEqual(expected, actual, message: "CreateNewOrder work incorrectly");
        }
        [Test]
        public void CheckoutByUser_EmptyBasket_Exception()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            registered.user = user;
            Assert.Throws<ArgumentException>(() => registered.Checkout("Name", "322324", "adress12"));
        }
        [Test]
        public void CheckoutByAdmin_EmptyBasket_Exception()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            Goods good = new Goods("goods", "desc", 10m);
            User user = new User("log", "123456");
            admin.user = user;
            Assert.Throws<ArgumentException>(() => admin.Checkout("Name", "322324", "adress12"));
        }
        [Test]
        public void ChangePersonalInformation_ChangeLogin_ChangedByUser()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
            
            User user = new User("log", "123456");
            registered.user = user;
            registered.ChangeProfile(new User("logg", "123456"));
            User expected = new User("logg", "123456");
            Assert.AreEqual(expected, registered.user, message: "Change login work incorrectly");
        }
        [Test]
        public void ChangePersonalInformation_ChangePassword_ChangedByUser()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Registered registered = new Registered(orders, goods, users);
           
            User user = new User("log", "123456");
            registered.user = user;
            registered.ChangeProfile(new User("log", "1234566"));
            User expected = new User("log", "1234566");
            Assert.AreEqual(expected, registered.user, message: "Change password work incorrectly");
        }
        [Test]
        public void ChangePersonalInformation_ChangeLogin_ChangedByAdmin()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            User userA = new User("loggg", "123456");
            User user = new User("log", "123456");
            users.Add(user);
            admin.user = userA;
            admin.ChangeProfile(user ,new User("logg", "123456"));
            User expected = new User("logg", "123456");
            User actual = users.GetAll().Where(u => u.Id == user.Id).Select(u => u).FirstOrDefault();
            Assert.AreEqual(expected, actual, message: "Change login work incorrectly");
        }
        [Test]
        public void ChangePersonalInformation_ChangePassword_ChangedByAdmin()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            User userA = new User("loggg", "123456");
            User user = new User("log", "123456");
            users.Add(user);
            admin.user = userA;
            admin.ChangeProfile(user, new User("log", "1234566"));
            User expected = new User("log", "1234566");
            User actual = users.GetAll().Where(u => u.Id == user.Id).Select(u => u).FirstOrDefault();
            Assert.AreEqual(expected, actual, message: "Change password work incorrectly");
        }
        [Test]
        public void AddGoods_NewGoods_AddToData()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            User userA = new User("loggg", "123456");
            admin.user = userA;
            Goods good = new Goods("Name2", "Descr2", 16m);
            admin.AddGoods(good);
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 16m) };
            Goods[] actual = admin.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "AddGoods work incorrectly");
        }
        [Test]
        public void ChangeGood_GoodsName_ChangeInfo()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            User userA = new User("loggg", "123456");
            admin.user = userA;
            Goods good = new Goods("Name2", "Descr2", 16m);
            admin.AddGoods(good);
            Goods goods1 = new Goods("Name5", "Descr2", 16m);
            admin.ChangeGood(goods1, good.Id);
            Goods[] expected = new Goods[] { new Goods("Name5", "Descr2", 16m) };
            Goods[] actual = admin.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "ChangeGood work incorrectly");
        }
        [Test]
        public void ChangeGood_GoodsDescription_ChangeInfo()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            User userA = new User("loggg", "123456");
            admin.user = userA;
            Goods good = new Goods("Name2", "Descr2", 16m);
            admin.AddGoods(good);
            Goods goods1 = new Goods("Name2", "Descr5", 16m);
            admin.ChangeGood(goods1, good.Id);
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr5", 16m) };
            Goods[] actual = admin.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "ChangeGood work incorrectly");
        }
        [Test]
        public void ChangeGood_GoodsPrice_ChangeInfo()
        {
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            IGoodsRepository goods = new GoodsRepository(new Repository<Goods>(context));
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            Admin admin = new Admin(orders, goods, users);
            User userA = new User("loggg", "123456");
            admin.user = userA;
            Goods good = new Goods("Name2", "Descr2", 16m);
            admin.AddGoods(good);
            Goods goods1 = new Goods("Name2", "Descr2", 18m);
            admin.ChangeGood(goods1, good.Id);
            Goods[] expected = new Goods[] { new Goods("Name2", "Descr2", 18m) };
            Goods[] actual = admin.ViewAllGoods().ToArray();
            Assert.AreEqual(expected, actual, message: "ChangeGood work incorrectly");
        }
    }
}