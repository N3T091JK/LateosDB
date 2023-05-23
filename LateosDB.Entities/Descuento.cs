using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Descuento
    {

        [Key]
        public int IdDescuento { get; set; }
        [MaxLength(80)]
        [Required]
        public string Nombre { get; set; }
        public Decimal Porcentaje { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }

    }
}
