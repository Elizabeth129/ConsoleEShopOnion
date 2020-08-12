using OA_DataAccess;
using System;
using System.Collections.Generic;

namespace OA_Service
{
    /// <summary>
    /// Interface for UserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Add new user to data
        /// </summary>
        /// <param name="user">New User</param>
        void Add(User user);
        /// <summary>
        /// Change information about user
        /// </summary>
        /// <param name="user">User which you want to change</param>
        /// <param name="temp">New information</param>
        void ChangePersonalInformation(User user, User temp);
        /// <summary>
        /// Get all users from data
        /// </summary>
        /// <returns>List of all users</returns>
        List<User> GetAll();
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User</returns>
        User GetById(int id);
    }
}
