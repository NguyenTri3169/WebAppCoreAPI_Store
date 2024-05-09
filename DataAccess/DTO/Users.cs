using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    [Table("Users")]
    public class Users
    {
        public int UserId { get; set; }
        [Column("UserName")]
        public string UserName { get; set; } = null!;
        [Column("UserPass")]
        public string UserPass { get; set; } = null!;
        [Column("FullName")]
        public string FullName { get; set; } = null!;
        [Column("IsAdmin")]
        public int IsAdmin { get; set; }
    }
    public class UserLogin_RequestData
    {
        [Column("UserName")]
        public string UserName { get; set; } = null!;
        [Column("UserPass")]
        public string UserPass { get; set; } = null!;
    }
}
