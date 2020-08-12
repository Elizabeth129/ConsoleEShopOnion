using OA_API.Controllers;
using OA_API.View;
using OA_DataAccess;
using OA_Repository;
using OA_Service;
using System;
using System.Collections.Generic;

namespace OA_API
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> usrer = new List<User>();
            var context = new ApplicationContext(new List<Goods>(), new List<User>(), new List<Order>());
            var orders = new OrderRepository(new Repository<Order>(context));
            var users = new UserRepository(new Repository<User>(context));
            var goods = new GoodsRepository(new Repository<Goods>(context));
            users.Add(new User { Login = "login", Password = "123456", Status = UserType.Administrator });
            goods.Add(new Goods { Name = "name1", Description = "kjhg", Price = 12m});
            var guest = new Guest(orders, goods, users);
            var admin = new Admin(orders, goods, users);
            var registered = new Registered(orders, goods, users);
            var guestView = new ViewGuest(guest);
            var registeredView = new ViewRegistered(registered);
            var admView = new ViewAdmin(admin);
            while (true)
            {
                guestView.Menu();
                if (guestView.Guest.user != null)
                {
                    if (guestView.Guest.user.Status == UserType.Registered)
                    {
                        registeredView.Registered.user = guestView.Guest.user;
                        registeredView.Menu();
                    }
                    else
                    {
                        admView.Admin.user = guestView.Guest.user;
                       admView.Menu();
                    }
                    guestView.Guest.user = null;
                }
            }
        }
    }
}
