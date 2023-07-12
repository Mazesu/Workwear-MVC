using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Workwear.Data;
using Workwear.Models;
using Workwear.Repository.IRepository;

namespace Workwear.Repository
{
    public class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
    {
        private ApplicationDbContext _db;
        public ProductSizeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductSize obj)
        {
            _db.ProductSizes.Update(obj);
        }

        public int GetProductSizeIdBySelectedSize(string selectedSize, int productId)
        {
            var productSize = _db.ProductSizes.FirstOrDefault(ps => ps.SizeName == selectedSize && ps.ProductId == productId);
            if (productSize != null)
            {
                return productSize.Id;
            }

            return 0; // Или другое подходящее значение по умолчанию, если размер не найден.
        }
    }
}
