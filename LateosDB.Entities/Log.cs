using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Log
        //Sele cambio donde decia tabla y ahora es password
    {
        [Key]
        public int logId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [MaxLength(80)]
        [Required]
        public string Usuario { get; set; }
        [MaxLength(80)]
        [Required]
        public string Password { get; set; }
        [MaxLength(80)]
        [Required]
        public string Accion { get; set; }
        [MaxLength(200)]
        [Required]
        public string Descripcion { get; set; }
    }
}
