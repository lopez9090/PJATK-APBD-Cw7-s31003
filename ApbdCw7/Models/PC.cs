using System.ComponentModel.DataAnnotations;

namespace ApbdCw7.Models;

public class PC
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public double Weight { get; set; }

    [Required]
    public int Warranty { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public int Stock { get; set; }
    
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}