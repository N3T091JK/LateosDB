using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Rol> Roles { get; set; }
    }
}
