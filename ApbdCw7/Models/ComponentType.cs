using System.ComponentModel.DataAnnotations;

namespace ApbdCw7.Models;

public class ComponentType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Component> Components { get; set; } = new List<Component>();
}