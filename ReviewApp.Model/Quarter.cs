using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Model
{
    [Table("Quarters")]
    public class Quarter
    {
        [Key]
        public int Id { get; set; }
        /*Added Code*/
        public string QuarterCode { get; set; } = string.Empty;
        public string QuarterName { get; set; } = string.Empty;
    }
}
