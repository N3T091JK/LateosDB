using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Log
    {
        [Key]
        public int logId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [MaxLength(80)]
        [Required]
        public string Email { get; set; }
        [MaxLength(80)]
        [Required]
        public string Password { get; set; }
    }
}
