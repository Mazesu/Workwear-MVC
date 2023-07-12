using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workwear.ViewModels;

namespace Workwear.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
    }
}
