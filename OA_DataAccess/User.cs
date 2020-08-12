using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OA_DataAccess
{
    /// <summary>
    /// Class user
    /// </summary>
    public class User : BaseEntity, IEquatable<User>
    {
        
        
        /// <summary>
        /// User login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User status - Administrator or Registered
        /// </summary>
        public UserType Status { get; set; }
        /// <summary>
        /// User basket
        /// </summary>
        public List<Goods> Basket { get; set; }
        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="login"> User login</param>
        /// <param name="password">User password</param>
        /// <param name="status">User status - Administrator or Registered</param>
        public User(string login, string password, UserType status = UserType.Registered)
        {
            Basket = new List<Goods>();
            Login = login;
            Password = password;
            Status = status;
            
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {

        }
        /// <summary>
        /// Comparison of two users
        /// </summary>
        /// <param name="other">Other user</param>
        /// <returns>True if users equals</returns>
        public bool Equals([AllowNull] User other)
        {
            if (this.Login == other.Login && this.Password == other.Password && this.Status == other.Status)
                return true;
            return false;
        }
    }
}
