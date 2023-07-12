using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workwear.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [DisplayName("Цена за 1-20")]
        public double Price { get; set; }
        [Required]
        [DisplayName("Цена за 20+")]
        public double Price20 { get; set; }
        [Required]
        [DisplayName("Цена за 50+")]
        public double Price50 { get; set; }
        [Required]
        [DisplayName("Цена за 100+")]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [ValidateNever]
        public ICollection<ProductSize> ProductSize { get; set; }

    }
}
