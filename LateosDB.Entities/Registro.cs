using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.Entities
{
    public class Registro
    {
        [Key]
        public int IdRegistro { get; set; }
        [MaxLength(80)]
        [Required]
        public string Nombre { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }
        public int IdCompraProducto { get; set; }
        public virtual CompraProducto CompraProductos { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuarios { get; set; }
        public int IdFactura { get; set; }
        public virtual Factura Facturas { get; set; }
        public int IdRol { get; set; }
        public virtual Rol Rols { get; set; }
        //public int IdEmpresa { get; set; }
        //public virtual Empresa Empresa { get; set; }
    }
}
