using System;
using System.Collections.Generic;
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

        [Required]
        public double Value { get; set; }  // This field could be used to store the entered value

        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // Foreign key

        public virtual Category? Category { get; set; }  // Navigation property
    }
}

