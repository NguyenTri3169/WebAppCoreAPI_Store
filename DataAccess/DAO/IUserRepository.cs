using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public interface IUserRepository
    {
        Task <Users> Login(UserLogin_RequestData requestData);    
    }
}
