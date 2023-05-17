namespace LateosDB.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LateosDBVentas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 40),
                        IdEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoria)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IdFactura = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        MontoPago = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacion = c.String(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdDetalleFactura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFactura)
                .ForeignKey("dbo.Clientes", t => t.IdCliente)
                .ForeignKey("dbo.DetalleFacturas", t => t.IdDetalleFactura)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdCliente)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdDetalleFactura);
            
            CreateTable(
                "dbo.DetalleFacturas",
                c => new
                    {
                        IdDetalleFactura = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        subTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleFactura)
                .ForeignKey("dbo.Productoes", t => t.IdProducto)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 80),
                        Nombre = c.String(nullable: false),
                        Decripcion = c.String(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaCaducidad = c.DateTime(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado)
                .Index(t => t.IdEstado)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        IdInventario = c.Int(nullable: false, identity: true),
                        CodigoN = c.String(nullable: false),
                        Stock = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                        Productos_IdProducto = c.Int(),
                    })
                .PrimaryKey(t => t.IdInventario)
                .ForeignKey("dbo.Productoes", t => t.Productos_IdProducto)
                .Index(t => t.Productos_IdProducto);
            
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        IdRegistro = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        IdCliente = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        IdCompraProducto = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdFactura = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRegistro)
                .ForeignKey("dbo.Clientes", t => t.IdCliente)
                .ForeignKey("dbo.CompraProductoes", t => t.IdCompraProducto)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado)
                .ForeignKey("dbo.Facturas", t => t.IdFactura)
                .ForeignKey("dbo.Rols", t => t.IdRol)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdCliente)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdCompraProducto)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdFactura)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.CompraProductoes",
                c => new
                    {
                        IdCompraProducto = c.Int(nullable: false, identity: true),
                        MarcaProducto = c.String(nullable: false, maxLength: 80),
                        Cantidad = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompraProducto);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        IdDetalleCompra = c.Int(nullable: false, identity: true),
                        CantidadProductos = c.String(nullable: false, maxLength: 80),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdCompraProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleCompra)
                .ForeignKey("dbo.CompraProductoes", t => t.IdCompraProducto)
                .Index(t => t.IdCompraProducto);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Apellido = c.String(maxLength: 80),
                        Direccion = c.String(maxLength: 80),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        Usuario_IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_IdUsuario)
                .Index(t => t.IdEstado)
                .Index(t => t.Usuario_IdUsuario);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Roles = c.String(nullable: false),
                        IdEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRol)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Correo = c.String(nullable: false),
                        Clave = c.String(nullable: false),
                        cantidades = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Rols", t => t.IdRol)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false, identity: true),
                        NombreComercial = c.String(nullable: false, maxLength: 80),
                        NombreLegal = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Rubro = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        logId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Usuario = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 80),
                        Accion = c.String(nullable: false, maxLength: 80),
                        Descripcion = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.logId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Rols");
            DropForeignKey("dbo.Registroes", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Facturas", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Empleadoes", "Usuario_IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Registroes", "IdRol", "dbo.Rols");
            DropForeignKey("dbo.Rols", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Registroes", "IdFactura", "dbo.Facturas");
            DropForeignKey("dbo.Registroes", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Registroes", "IdCompraProducto", "dbo.CompraProductoes");
            DropForeignKey("dbo.DetalleCompras", "IdCompraProducto", "dbo.CompraProductoes");
            DropForeignKey("dbo.Registroes", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Inventarios", "Productos_IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.DetalleFacturas", "IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Facturas", "IdDetalleFactura", "dbo.DetalleFacturas");
            DropForeignKey("dbo.Facturas", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Categorias", "IdEstado", "dbo.Estadoes");
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropIndex("dbo.Rols", new[] { "IdEstado" });
            DropIndex("dbo.Empleadoes", new[] { "Usuario_IdUsuario" });
            DropIndex("dbo.Empleadoes", new[] { "IdEstado" });
            DropIndex("dbo.DetalleCompras", new[] { "IdCompraProducto" });
            DropIndex("dbo.Registroes", new[] { "IdRol" });
            DropIndex("dbo.Registroes", new[] { "IdFactura" });
            DropIndex("dbo.Registroes", new[] { "IdUsuario" });
            DropIndex("dbo.Registroes", new[] { "IdCompraProducto" });
            DropIndex("dbo.Registroes", new[] { "IdEmpleado" });
            DropIndex("dbo.Registroes", new[] { "IdCliente" });
            DropIndex("dbo.Inventarios", new[] { "Productos_IdProducto" });
            DropIndex("dbo.Productoes", new[] { "IdCategoria" });
            DropIndex("dbo.Productoes", new[] { "IdEstado" });
            DropIndex("dbo.DetalleFacturas", new[] { "IdProducto" });
            DropIndex("dbo.Facturas", new[] { "IdDetalleFactura" });
            DropIndex("dbo.Facturas", new[] { "IdUsuario" });
            DropIndex("dbo.Facturas", new[] { "IdCliente" });
            DropIndex("dbo.Clientes", new[] { "IdEstado" });
            DropIndex("dbo.Categorias", new[] { "IdEstado" });
            DropTable("dbo.Logs");
            DropTable("dbo.Empresas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Rols");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.CompraProductoes");
            DropTable("dbo.Registroes");
            DropTable("dbo.Inventarios");
            DropTable("dbo.Productoes");
            DropTable("dbo.DetalleFacturas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Categorias");
        }
    }
}
