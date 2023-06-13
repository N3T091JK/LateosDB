using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Compra
    {
        [Key]
        public int IdCompraProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public decimal Subtotal { get; set; }
        public int IdProducto { get; set; }
        [Required]
        public int IdCPComprar { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual ComprarProducto ComprarProductos { get; set; }
    }
}
