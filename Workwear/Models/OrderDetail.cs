using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workwear.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int ProductSizeId { get; set; }
        [ForeignKey("ProductSizeId")]
        [ValidateNever]
        public ProductSize ProductSize { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
