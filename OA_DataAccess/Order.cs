using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OA_DataAccess
{
    /// <summary>
    /// Class order
    /// </summary>
    public class Order : BaseEntity, IEquatable<Order>
    {

        
        
        /// <summary>
        /// Customer Login
        /// </summary>
        public string CustomerLogin { get; set; }
        /// <summary>
        /// List of Goods from basket
        /// </summary>
        public List<Goods> Goods { get; set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Customer Phone Number
        /// </summary>
        public string CustomerPhoneNumber { get; set; }
        /// <summary>
        /// Delivery Address
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// DateTime now
        /// </summary>
        public DateTime dateTimeOfOrder { get; set; }
        /// <summary>
        /// Order Status
        /// </summary>
        public OrderStatus orderStatus { get; set; }

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="customerLogin"> Customer Login</param>
        /// <param name="customerName"> Customer Name</param>
        /// <param name="customerPhoneNumber"> Customer Phone Number</param>
        /// <param name="deliveryAddress">Delivery Address</param>
        /// <param name="goods">List of Goods from basket</param>
        public Order(string customerLogin, string customerName, string customerPhoneNumber, string deliveryAddress, List<Goods> goods)
        {
            CustomerLogin = customerLogin;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
            DeliveryAddress = deliveryAddress;
            Goods = goods;
            dateTimeOfOrder = DateTime.Now;
            orderStatus = OrderStatus.NewOrder;
            
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Order()
        {

        }
        /// <summary>
        /// Comparison of two orders
        /// </summary>
        /// <param name="other">Other order</param>
        /// <returns>True if orders equals</returns>
        public bool Equals([AllowNull] Order other)
        {
            if (this.CustomerLogin == other.CustomerLogin && this.CustomerName == other.CustomerName
                && this.CustomerPhoneNumber == other.CustomerPhoneNumber && this.DeliveryAddress == other.DeliveryAddress
              && this.orderStatus == other.orderStatus)
                return true;
            return false;
        }
    }
}
