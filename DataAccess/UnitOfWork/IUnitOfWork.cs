using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategory _category { get; set; }

        public IUserRepository _userRepository { get; set; }
        int SaveChange();
    }
}
