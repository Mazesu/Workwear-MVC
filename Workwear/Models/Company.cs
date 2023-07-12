using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Workwear.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Полное название")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("Короткое название")]
        public string ShortName { get; set; }
        [Required]
        [DisplayName("ИНН")]
        public string INN { get; set; }
        [Required]
        [DisplayName("КПП")]
        public string KPP { get; set; }
        [Required]
        [DisplayName("ОГРН")]
        public string OGRN { get; set; }
        public string? City { get; set; }
        [Required]
        [DisplayName("Юридический адрес")]
        public string LegalAddress { get; set; }
        [Required]
        [DisplayName("Фактический адрес")]
        public string ActualAddress { get; set; }
        [Required]
        [DisplayName("Почтовый индекс")]
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
