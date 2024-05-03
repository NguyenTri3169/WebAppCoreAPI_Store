namespace WebAppCoreMVC.Models
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(StoreContext context) : base(context)
        {
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
