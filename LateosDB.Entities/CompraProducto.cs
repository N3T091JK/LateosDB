using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class CompraProducto
    {

        [Key]
        public int IdCompraProducto { get; set; }
        [MaxLength(80)]
        [Required]
        public string MarcaProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
