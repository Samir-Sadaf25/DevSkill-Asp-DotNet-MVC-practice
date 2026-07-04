using System.ComponentModel.DataAnnotations;
using Demo.Domain.Contracts;

namespace Demo.web.Areas.Admin.Models;

public class ProductModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Range(0.01, 999999)]
    public double Price { get; set; }
}