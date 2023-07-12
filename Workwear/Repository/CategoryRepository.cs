using System.Linq.Expressions;
using Workwear.Data;
using Workwear.Models;
using Workwear.Repository.IRepository;

namespace Workwear.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
