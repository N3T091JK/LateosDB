using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Rol
    {
        //Revisar las llaves foraneas alguna esta mala 

        [Key]
        public int IdRol { get; set; }
        [Required]
        public string Roles { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
