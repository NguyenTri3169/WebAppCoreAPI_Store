using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.DbContext
{
    public class StoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; } = null!;
    }
}
