using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [MaxLength(80)]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(80)]
        public string Apellido { get; set; }
        [MaxLength(80)]
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
