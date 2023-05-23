using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class CompraRealizada
    {
        [Key]
        public int IdComprar { get; set; }
        [MaxLength(80)]
        [Required]
        public string Codigo { get; set; }
        public int IdFactura { get; set; }
        public virtual Factura Facturas { get; set; }
        public int IdDetalleFactura { get; set; }
        public virtual DetalleFactura DetalleFactura { get; set; }

    }
}
