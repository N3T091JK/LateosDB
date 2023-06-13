using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        [Required]
        //Eliminar clave
        //public string Clave { get; set; }
        //[Required]
        public string Password { get; set; }
        //Eliminar cantidad
        //public int cantidades { get; set; }
        //[Required]
        public int IdEstado { get; set; }
        public virtual Estado Estados { get; set; }
        public int IdRol { get; set; }
        public virtual Rol Rols { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
