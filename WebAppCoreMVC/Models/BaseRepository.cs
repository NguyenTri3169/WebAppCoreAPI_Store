namespace WebAppCoreMVC.Models
{
    public abstract class BaseRepository
    {
        protected StoreContext _context;
        public BaseRepository(StoreContext context)
        {
            this._context = context;
        }
    }
}
