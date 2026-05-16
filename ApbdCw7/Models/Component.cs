using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApbdCw7.Models;

public class Component
{
    [Key]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public int ComponentManufacturersId { get; set; }
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer Manufacturer { get; set; } = null!;

    public int ComponentTypesId { get; set; }
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType Type { get; set; } = null!;
    
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}