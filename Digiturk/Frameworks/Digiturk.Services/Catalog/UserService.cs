using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digiturk.Core;
using Digiturk.Core.Caching;
using Digiturk.Core.Data;
using Digiturk.Core.Domain.Catalog;

namespace Digiturk.Services.Catalog
{
    public class UserService : IUserService
    {

        #region Fields

        private readonly ICacheManager _cacheManager;
        private readonly IRepository<User> _userRepository;


        #endregion

        #region Ctor

        public UserService(ICacheManager cacheManager,
            IRepository<User> userRepository)
        {
            _cacheManager = cacheManager;
             _userRepository = userRepository;
           
        }

        #endregion

        #region Methods

        public void DeleteUser(User user)
        {

            if (user == null)
                throw new ArgumentNullException("user");

            user.Deleted = true;
            UpdateUser(user);
        }

        public IPagedList<User> GetAllUsers(string userName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _userRepository.Table;

            if (!showHidden)
                query = query.Where(m => m.Published);

            query = query.Where(m => !m.Deleted);

            query = query.Distinct().OrderBy(m => m.Id);

            return new PagedList<User>(query, pageIndex, pageSize);

        }

        public User GetUserById(int userId)
        {
            if (userId == 0)
                return null;

            return _userRepository.GetById(userId);
        }

        public void InsertUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Update(user);
        }

        #endregion
    }
}
