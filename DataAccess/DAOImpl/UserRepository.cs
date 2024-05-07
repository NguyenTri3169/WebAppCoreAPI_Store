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
        private readonly StoreDbContext _storeDbContext = null!;
        public UserRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }   
        public Task<int> Login(UserLogin_RequestData requestData)
        {
            try
            {
                
            }
            catch (Exception EX)
            {

                throw ex;
            }
        }
    }
}
