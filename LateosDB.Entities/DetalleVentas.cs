using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class DetalleVentas
    {

        [Key]

        public int IdDetalleVenta { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]

        public decimal Subtotal { get; set; }


        [Required]

        public int IdProducto { get; set; }
        [Required]
        public int IdVenta { get; set; }
        //de uno a uno
        public virtual Ventas Ventas { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
