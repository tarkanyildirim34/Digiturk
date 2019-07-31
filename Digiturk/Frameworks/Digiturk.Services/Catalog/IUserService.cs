using System.Collections.Generic;
using Digiturk.Core;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public interface IUserService
    {
        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="user">User</param>
        void DeleteUser(User user);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <param name="userName">User name</param> 
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Users</returns>
        IPagedList<User> GetAllUsers(string userName = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false);


        /// <summary>
        /// Gets a user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>User</returns>
        User GetUserById(int userId);

        /// <summary>
        /// Inserts a user
        /// </summary>
        /// <param name="user">User</param>
        void InsertUser(User user);

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">User</param>
        void UpdateUser(User user);
    }
}
