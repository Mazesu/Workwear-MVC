using System.Linq.Expressions;
using Workwear.Data;
using Workwear.Models;
using Workwear.Repository.IRepository;

namespace Workwear.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
