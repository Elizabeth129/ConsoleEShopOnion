using OA_DataAccess;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Service
{
    /// <summary>
    /// Class to implement IUserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Id of user
        /// </summary>
        private int Id;
        /// <summary>
        /// Repository of users
        /// </summary>
        private IRepository<User> _repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository">Repository of users</param>
        public UserRepository(IRepository<User> repository)
        {
            Id = 0;
            _repository = repository;
        }
        /// <summary>
        /// Add new user to data
        /// </summary>
        /// <param name="user">New User</param>
        public void Add(User user)
        {
            user.Id = Id;
            Id++;
            _repository.Add(user);
        }
        /// <summary>
        /// Change information about user
        /// </summary>
        /// <param name="user">User which you want to change</param>
        /// <param name="temp">New information</param>
        public void ChangePersonalInformation(User user, User temp)
        {

            if (temp.Login != null) user.Login = temp.Login;
            if (temp.Password != null) user.Password = temp.Password;
        }
        /// <summary>
        /// Get all users from data
        /// </summary>
        /// <returns>List of all users</returns>
        public List<User> GetAll()
        {
            return _repository.GetAll();
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User</returns>
        public User GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
