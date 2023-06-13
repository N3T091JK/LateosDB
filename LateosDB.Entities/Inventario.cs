using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Inventario
        //Modificar el formulario de Inventario
    {
        [Key]
        public int IdInventario { get; set; }
        [ForeignKey("Productos")]
        public int IdProduto { get; set; }
        [Required]
        public int cantidad { get; set; }            
        public virtual Producto Productos { get; set; }
    }
}
