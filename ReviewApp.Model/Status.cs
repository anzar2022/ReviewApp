using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewApp.Model
{
    [Table("Statuses")]
    [Index(nameof(StatusCode), IsUnique = true)]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusCode { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
    }
}
