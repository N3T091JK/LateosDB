using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Categoria
    {
        [Key]//Para que sea key si se quiere Code
        public int IdCategoria { get; set; }
        [MaxLength(40)]//Longitud de la cadena de nombre
        [Required]//No permite valores nulos]
        public string Nombre { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}
