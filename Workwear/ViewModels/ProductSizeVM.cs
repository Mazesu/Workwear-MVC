using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Workwear.Models;

namespace Workwear.ViewModels
{
    public class ProductSizeVM
    {
        public ProductSize ProductSize { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ProductList { get; set; }
    }
}
