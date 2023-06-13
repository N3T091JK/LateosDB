using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class ComprarProducto
    {
        [Key]
        public int IdCPComprar { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal TotalesRealizadas { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
