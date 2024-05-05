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
    public class CategoryImpl : ICategory
    {
        StoreDbContext _storeDbContext;
        public CategoryImpl(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public int Add(Category category)
        {
            throw new NotImplementedException();
        }

        public int Create(Category category)
        {
            _storeDbContext.categories.Add(category);
            return 1;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Edit(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            return _storeDbContext.categories.ToList();
        }

        public Category GetCategory(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
