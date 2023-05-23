using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        [Required]
        public int CantidadProductos { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public int IdCompraProducto { get; set; }
        public virtual CompraProducto CompraProductos { get; set; }

    }
}
