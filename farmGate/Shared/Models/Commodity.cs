using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace farmGate.Shared.Models
{
    public class Commodity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("comm_ID")]
        public int CommID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("commodity")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Column("comm_Desc")]
        public string Description { get; set; }

        [Column("cat_ID")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Column("volUnitID")]
        public int? VolumeUnitID { get; set; }

        [Column("avgPriceUnitID")]
        public int? AvgPriceUnitID { get; set; }

        public decimal? Volume { get; set; }
        public decimal? Multiplier { get; set; }
        public decimal? NoBatches { get; set; }
        public decimal? AvgYield { get; set; }
        public decimal? AvgPrice { get; set; }
        public int? NoHouses { get; set; }
        public bool? Active { get; set; }

        [ForeignKey("VolumeUnitID")]
        public virtual Unit VolumeUnit { get; set; }

        [ForeignKey("AvgPriceUnitID")]
        public virtual Unit AvgPriceUnit { get; set; }
    }
}
