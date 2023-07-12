using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Workwear.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}
