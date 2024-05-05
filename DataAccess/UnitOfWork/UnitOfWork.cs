using DataAccess.DAO;
using DataAccess.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable // Add IDisposable (không giữ connect đến DB, gây lock DB )
    {
        StoreDbContext _storeDbContext = null!;
        public ICategory _category { get; set; } = null!;
        public UnitOfWork(StoreDbContext storeDbContext, ICategory category)
        {
            _storeDbContext = storeDbContext;
            _category = category;
        }

        public int SaveChange()
        {
            return _storeDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _storeDbContext.Dispose();
        }
    }
}
