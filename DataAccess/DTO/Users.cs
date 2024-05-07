using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPass { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int IsAdmin { get; set; }
    }
    public class UserLogin_RequestData
    {
        public string UserName { get; set; } = null!;
        public string UserPass { get; set; } = null!;
    }
}
