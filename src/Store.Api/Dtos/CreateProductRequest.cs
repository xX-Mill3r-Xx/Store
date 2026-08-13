using System.ComponentModel.DataAnnotations;

namespace Store.Api.Dtos
{
    public class CreateProductRequest
    {
        [Required]
        [StringLength(100)]
        public string Nmar {  get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
