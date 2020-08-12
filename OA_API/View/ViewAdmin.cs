using OA_API.Controllers;
using OA_DataAccess;
using OA_Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OA_API.View
{
    /// <summary>
    /// View for Admin
    /// </summary>
    class ViewAdmin
    {
        /// <summary>
        /// Instance of Admin controler
        /// </summary>
        public readonly Admin Admin;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="admin">Admin controler</param>
        
        public ViewAdmin(Admin admin)
        {
            Admin = admin;
     
        }
        /// <summary>
        /// Menu for Admin
        /// </summary>
        public void Menu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("------------------------------");
             if (Admin.user == null) return;
                Console.WriteLine("Enter the number:\n" +
                "1 - Show All Goods\n" +
                "2 - Find Good With Name\n" +
                "3 - Create a new Order\n" +
                "4 - Complete Order\n" +
                "5 - Deny Order\n" +
                "6 - List of Users\n" +
                "7 - Change User Profile\n" +
                "8 - Add Good\n" +
                "9 - Change Good\n" +
                "10 - List of Orders\n" +
                "11 - Change Order Status\n" +
                "12 - Log out"
             );
                flag = HandleMenu();
            }
            Admin.user = null;
        }
        /// <summary>
        /// Handle of Admin menu
        /// </summary>
        public bool HandleMenu()
        {
            try
            {
                int key;
                key = Int32.Parse(Console.ReadLine());
                if ((key < 1) || (key > 12)) { Console.WriteLine("Wrong Input"); return true; }
                if (key == 12) return false;
                List<Action> action = new List<Action>();
                action.Add(ShowAllProducts);
                action.Add(SearchGoodsByName);
                action.Add(CreateNewOrder);
                action.Add(CheckoutOrder);
                action.Add(DenyOrder);
                action.Add(ShowUsers);
                action.Add(ChangeUserProfile);
                action.Add(AddGoods);
                action.Add(ChangeGoods);
                action.Add(ShowAllOrders);
                action.Add(ChangeOrderStatus);
           
                action[key - 1].Invoke();
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return true;
            }

        }
        /// <summary>
        ///  Show all goods from data
        /// </summary>
        public void ShowAllProducts()
        {
            List<Goods> goods = Admin.ViewAllGoods();
            foreach (Goods g in goods)
            {
                Console.WriteLine("ID:" + g.Id);
                Console.WriteLine("Name:" + g.Name);
                Console.WriteLine("Description:" + g.Description);
                Console.WriteLine("Price:" + g.Price + "$");
            }
        }
        /// <summary>
        /// Show all orders from data
        /// </summary>
        public void ShowAllOrders()
        {
            List<Order> orders = Admin.ViewAllOrders();
            foreach (Order o in orders)
            {

                Console.WriteLine("Order Id: " + o.Id);
                Console.WriteLine("Customer Name: " + o.CustomerName);
                Console.WriteLine("Customer PhoneNumber: " + o.CustomerPhoneNumber);
                Console.WriteLine("DeliveryAddress: " + o.DeliveryAddress);
                Console.WriteLine("Order Status: " + o.orderStatus);
                foreach (Goods g in o.Goods)
                {
                    Console.WriteLine("ID:" + g.Id);
                    Console.WriteLine("Name:" + g.Name);
                    Console.WriteLine("Description:" + g.Description);
                    Console.WriteLine("Price:" + g.Price + "$");
                }
            }
        }
        /// <summary>
        /// Change order status
        /// Input order id
        /// Input new status
        /// </summary>
        public void ChangeOrderStatus()
        {
            Console.WriteLine("Input order id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            OrderStatus orderStatus;

            int key;
            Console.WriteLine("Choose what you want to change:");
            Console.WriteLine("1 - PaymentReceived\n" +
                "2 - Sent\n" +
                "3 - Received\n" +
                "4 - Completed\n" +
                "5 - CanceledByAdministrator\n");
            key = Int32.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    orderStatus = OrderStatus.PaymentReceived;
                    break;
                case 2:
                    orderStatus = OrderStatus.Sent;
                    break;
                case 3:
                    orderStatus = OrderStatus.Received;
                    break;
                case 4:
                    orderStatus = OrderStatus.Completed;
                    break;
                case 5:
                    orderStatus = OrderStatus.CanceledByAdministrator;
                    break;
                default:
                    orderStatus = OrderStatus.CanceledByAdministrator;
                    break;
            }
            Admin.ChangeStatus(id, orderStatus);
        }
        /// <summary>
        /// Show goods whith such name
        /// </summary>
        public void SearchGoodsByName()
        {
            string name = "";
            Console.WriteLine("Input name of goods");
            name = Console.ReadLine();
            List<Goods> goods = Admin.SearchByName(name);
            if (goods.Count == 0)
            {
                Console.WriteLine("Nothing found");
            }
            else
            {
                foreach (Goods g in goods)
                {
                    Console.WriteLine("ID:" + g.Id);
                    Console.WriteLine("Name:" + g.Name);
                    Console.WriteLine("Description:" + g.Description);
                    Console.WriteLine("Price:" + g.Price + "$");
                }
            }

        }
        /// <summary>
        /// Add goods to user basket
        /// Input goods id 
        /// </summary>
        public void CreateNewOrder()
        {
            Console.WriteLine("Input good id");
            while (true)
            {

                int id = Convert.ToInt32(Console.ReadLine());
                if (id == -1) break;
                if (Admin.ViewAllGoods().Where(g => g.Id == id).Select(g => g).Count() > 0)
                {
                    Admin.AddToBasket(Admin.ViewAllGoods().Where(g => g.Id == id).Select(g => g).FirstOrDefault());
                }
                else
                {
                    Console.WriteLine("Nothing found");
                }
                Console.WriteLine("If you want end add to basket input -1 or goods id");
            }
        }
        /// <summary>
        /// Create new order
        /// Input order information
        /// </summary>
        public void CheckoutOrder()
        {
            Console.WriteLine("Input customer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Input customer phone: ");
            string customerPhoneNumber = Console.ReadLine();
            Console.WriteLine("Input delivery address: ");
            string deliveryAddress = Console.ReadLine();
            Admin.Checkout(customerName, customerPhoneNumber, deliveryAddress);
        }
        /// <summary>
        /// Deny order 
        /// Input order id
        /// </summary>
        public void DenyOrder()
        {
            Console.WriteLine("Input order id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (Admin.DenyOrder(id))
            {
                Console.WriteLine("Order was denied.");
            }
            else Console.WriteLine("Wrong id.");
        }
        /// <summary>
        /// Show all users from data
        /// </summary>
        public void ShowUsers()
        {
            List<User> users = Admin.ShowAllUsers();
            foreach (User u in users)
            {
                Console.WriteLine("User ID:" + u.Id);
                Console.WriteLine("User Login:" + u.Login);
                Console.WriteLine("User Password:" + u.Password);
                Console.WriteLine("User Status:" + u.Status.ToString());
            }
        }
        /// <summary>
        /// Change user information
        /// Input user id
        /// Input new information
        /// </summary>
        public void ChangeUserProfile()
        {
            User u;
            Console.WriteLine("Input user Id: ");
            while (true)
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (Admin.ShowAllUsers().Where(u => u.Id == id).Select(u => u).Count() > 0)
                {
                    u = Admin.ShowAllUsers().Where(u => u.Id == id).Select(u => u).FirstOrDefault();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Id. Input another: ");
                }
            }
            User user = new User(null, null);
            bool flag = true;
            int key;
            while (flag)
            {
                Console.WriteLine("Choose what you want to change:");
                Console.WriteLine(
                    "1 - Login\n" +
                    "2 - Password\n" +
                    "3 - SaveChanges\n");
                key = Int32.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        user.Login = Change();
                        break;
                    case 2:
                        user.Password = Change();
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
            Admin.ChangeProfile(u, user);
        }
        /// <summary>
        /// Input new information
        /// </summary>
        /// <returns>New info</returns>
        private string Change()
        {
            Console.WriteLine("Enter new one:");
            string temp = Console.ReadLine();
            return temp;
        }
        /// <summary>
        /// Add new goods to data
        /// Input good information
        /// </summary>
        public void AddGoods()
        {
            Goods good = new Goods(null, null, 0);
            Console.WriteLine("Input the name of Good:");
            good.Name = Console.ReadLine();
            Console.WriteLine("Input the good description");
            good.Description = Console.ReadLine();
            Console.WriteLine("Input the good Price");
            good.Price = Decimal.Parse(Console.ReadLine());
            Admin.AddGoods(good);
        }
        /// <summary>
        /// Change goods information
        /// Input goods id
        /// Input new information
        /// </summary>
        public void ChangeGoods()
        {
            Goods g;
            Console.WriteLine("Input good Id: ");
            while (true)
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (Admin.ViewAllGoods().Where(u => u.Id == id).Select(u => u).Count() > 0)
                {
                    g = Admin.ViewAllGoods().Where(u => u.Id == id).Select(u => u).FirstOrDefault();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Id. Input another: ");
                }
            }
            Goods good = new Goods(null, null, 0);
            bool flag = true;
            int key;
            while (flag)
            {
                Console.WriteLine("Choose what you want to change:");
                Console.WriteLine(
                    "1 - Description\n" +
                    "2 - Name\n" +
                    "3 - Price\n" +
                    "4 - SaveChanges\n");
                key = Int32.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        good.Description = Change();
                        break;
                    case 2:
                        good.Name = Change();
                        break;
                    case 3:
                        good.Price = Convert.ToDecimal(Change());
                        break;
                    case 4:
                        flag = false;
                        break;
                }
            }
            Admin.ChangeGood(good, g.Id);
        }
       
    }
}
