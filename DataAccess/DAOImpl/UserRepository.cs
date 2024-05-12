using DataAccess.DAO;
using DataAccess.DbContext;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOImpl
{
    public class UserRepository : IUserRepository
    {
        private StoreDbContext _storeDbContext;
        public UserRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task<Users> Login(UserLogin_RequestData requestData)
        {
            var user = new Users();
            try
            {
                user = _storeDbContext.users.Where(x => x.UserName == requestData.UserName && x.UserPass == requestData.UserPass)
                    .FirstOrDefault();
            }
            catch (Exception EX)
            {
                throw; // rethrow the exception without modifying it
            }
            return user;
        }

        public async Task<int> UpdateRefreshTokenExpired(UpdateRefreshTokenExpired_RequestData requestData)
        {
            var result = 0;
            try
            {
                var user = _storeDbContext.users.Where(x => x.UserId == requestData.UserId)
                    .FirstOrDefault();
                if (user != null && user.UserId > 0)
                {
                    user.RefreshToken = requestData.RefreshToken;
                    user.RefreshTokenExpired = requestData.RefreshTokenExpired;
                    _storeDbContext.Update(user);
                }
                return result = 1;
            }
            catch (Exception EX)
            {

                return result = -99;
            }
        }
    }
}
