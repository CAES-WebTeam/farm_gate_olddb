using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmGate.Shared.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cat_ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("category")]
        public string? Name { get; set; }

        public virtual List<Commodity> Commodities { get; set; }
    }
}
