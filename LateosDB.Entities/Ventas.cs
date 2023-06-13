using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }
        [Required]
        public decimal TotalVenta { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdEstado { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        //de uno a uno
        //public virtual ICollection <VentaDetalle> VentaDetalle { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<DetalleVentas> DetalleVentas { get; set; }
    }
}
