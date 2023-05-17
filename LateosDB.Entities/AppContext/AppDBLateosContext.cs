using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LateosDB.Entities.AppContext;

namespace LateosDB.Entities.AppContext
{
    class AppDBLateosContext : DbContext
    {
        public AppDBLateosContext() : base("conn")
        {

        }
        public DbSet<Categoria> categorias { get; set; }       
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<CompraProducto> compraProductos { get; set; }
        public DbSet<DetalleCompra> detalleCompras { get; set; }
        public DbSet<DetalleFactura> detalleFacturas { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Factura> facturas { get; set; }
        public DbSet<Inventario> inventarios { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Registro> Registros { get; set; }
    }
}
