using Workwear.Models;

namespace Workwear.Repository.IRepository
{
    public interface IProductSizeRepository : IRepository<ProductSize>
    {
        void Update(ProductSize obj);
        int GetProductSizeIdBySelectedSize(string selectedSize, int productId);
    }
}
