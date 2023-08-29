using System.ComponentModel.DataAnnotations;

public class Unit
{
    [Key]
    public int UnitID { get; set; }
    public string? FullName { get; set; }
    public string? Abbreviation { get; set; }
}
