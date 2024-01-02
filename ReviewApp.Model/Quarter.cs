using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
