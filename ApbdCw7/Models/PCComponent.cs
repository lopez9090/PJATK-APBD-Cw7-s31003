using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApbdCw7.Models;

public class PCComponent
{
    public int PCId { get; set; }
    [ForeignKey(nameof(PCId))]
    public PC PC { get; set; } = null!;

    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;

    [Required]
    public int Amount { get; set; }
}