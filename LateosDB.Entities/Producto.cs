using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Producto
    {
        //Modificar el formulario de Producto
        [Key]
        public int IdProducto { get; set; }
        [MaxLength(80)]
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Decripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }

        public DateTime FechaCaducidad { get; set; }
        [Required]
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria Category { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }        
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }

    }
}
