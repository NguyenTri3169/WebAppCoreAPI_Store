using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public interface ICategory
    {
        int Add(Category category);
        int Edit(Category category);

        int Delete(int id);
        List<Category> GetCategories();
        Category GetCategory(int Id);
    }
}
