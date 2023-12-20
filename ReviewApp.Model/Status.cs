using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Model
{
    [Table("Statuses")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}
