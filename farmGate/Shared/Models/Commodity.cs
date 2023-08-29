using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmGate.Shared.Models
{
    public class Commodity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // Foreign key

        public virtual Category Category { get; set; }  // Navigation property

        public int UnitID { get; set; }  // Foreign Key
        public Unit Unit { get; set; }  // Navigation Property
    }
}

