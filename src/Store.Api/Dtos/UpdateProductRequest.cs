using System.ComponentModel.DataAnnotations;

namespace Store.Api.Dtos;

public sealed class UpdateProductRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
}
