using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace WebAppCoreMVC.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } = null!;

    }
}
