using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.Model
{
    [Table("Quarters")]
    [Index(nameof(QuarterCode), IsUnique = true)]
    public class Quarter
    {
        [Key]
        public int Id { get; set; }
        public string QuarterCode { get; set; } = string.Empty;
        public string QuarterName { get; set; } = string.Empty;
    }
}
