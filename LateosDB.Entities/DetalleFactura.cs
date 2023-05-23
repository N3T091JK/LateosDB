using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class DetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public decimal subTotal { get; set; }
        public int IdProducto { get; set; }
        public virtual Producto Productos { get; set; }
        public virtual ICollection<CompraRealizada> CompraRealizadas { get; set; }
    }
}
