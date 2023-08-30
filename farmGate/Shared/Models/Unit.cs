using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Unit
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UnitID { get; set; }

    [Required]
    [MaxLength(25)]
    public string UnitSingular { get; set; }

    [Required]
    [MaxLength(25)]
    public string UnitPlural { get; set; }

    [Required]
    public bool House { get; set; }

    [Required]
    public bool Volume { get; set; }

    [Required]
    public bool Price { get; set; }
}
