using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Factura
    //Se le agrego un campo nuevo codigo
    {
        [Key]
        public int IdFactura { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public Decimal MontoPago { get; set; }
        [Required]
        public Decimal MontoTotal { get; set; }
        [Required]
        public string Observacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Clientes{ get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuarios{ get; set; }
        public int IdDescuento { get; set; }
        public virtual Descuento Descuentos { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<CompraRealizada> CompraRealizadas { get; set; }
    }
}
