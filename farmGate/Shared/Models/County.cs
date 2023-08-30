using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmGate.Shared.Models
{
    public class County
    {
        [Column("county_fips")]
        public int Id { get; set; }

        [Column("countyName")]
        public string? Name { get; set; }
        // Add other properties as needed

   
    }
}

