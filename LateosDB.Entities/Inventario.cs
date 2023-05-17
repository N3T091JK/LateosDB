using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string CodigoN { get; set; }
        public int Stock { get; set; }
        [Required]
        public int IdProduto { get; set; }             
        public virtual Producto Productos { get; set; }
    }
}
