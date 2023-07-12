using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Workwear.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [BindProperty]
        public int ProductSizeId { get; set; }
        [ForeignKey("ProductSizeId")]
        [ValidateNever]
        public ProductSize ProductSize { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; }
        public string Size { get; set; }
    }
}
