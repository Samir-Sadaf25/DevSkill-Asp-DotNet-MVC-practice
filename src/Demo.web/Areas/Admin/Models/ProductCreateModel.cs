using System.ComponentModel.DataAnnotations;

namespace Demo.web.Areas.Admin.Models;

public class ProductCreateModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(200)] 
    public string Name { get; set; }
    [Range(0.01,999999)]
    public double Price { get; set; }
}
