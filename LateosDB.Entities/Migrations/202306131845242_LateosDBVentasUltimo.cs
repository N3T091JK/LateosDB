namespace LateosDB.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LateosDBVentasUltimo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 40),
                        CantidaCategoria = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoria)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado )
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Estado_IdEstado = c.Int(),
                    })
                .PrimaryKey(t => t.IdEstado)
                .ForeignKey("dbo.Estadoes", t => t.Estado_IdEstado)
                .Index(t => t.Estado_IdEstado);
            
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
                .ForeignKey("dbo.Estadoes", t => t.IdEstado )
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        IdRegistro = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        IdCliente = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRegistro)
                .ForeignKey("dbo.Clientes", t => t.IdCliente    )
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado)
                .ForeignKey("dbo.Rols", t => t.IdRol)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdCliente)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdRol);
            
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
                        Correo = c.String(),
                        Password = c.String(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Estadoes", t => t.IdEstado)
                .ForeignKey("dbo.Rols", t => t.IdRol)
                .Index(t => t.IdEstado)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        IdVenta = c.Int(nullable: false, identity: true),
                        FechaVenta = c.DateTime(nullable: false),
                        TotalVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdCliente = c.Int(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenta)
                .ForeignKey("dbo.Clientes", t => t.IdCliente)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuario)
                .Index(t => t.IdCliente)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        IdDetalleVenta = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdProducto = c.Int(nullable: false),
                        IdVenta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleVenta)
                .ForeignKey("dbo.Productoes", t => t.IdProducto)
                .ForeignKey("dbo.Ventas", t => t.IdVenta)
                .Index(t => t.IdProducto)
                .Index(t => t.IdVenta);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 80),
                        Nombre = c.String(nullable: false),
                        CodigoBarra = c.String(maxLength: 12),
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
                "dbo.Compras",
                c => new
                    {
                        IdCompraProducto = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdProducto = c.Int(nullable: false),
                        IdCPComprar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompraProducto)
                .ForeignKey("dbo.ComprarProductoes", t => t.IdCPComprar)
                .ForeignKey("dbo.Productoes", t => t.IdProducto)
                .Index(t => t.IdProducto)
                .Index(t => t.IdCPComprar);
            
            CreateTable(
                "dbo.ComprarProductoes",
                c => new
                    {
                        IdCPComprar = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        TotalesRealizadas = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdCPComprar);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        IdInventario = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdInventario)
                .ForeignKey("dbo.Productoes", t => t.IdProduto)
                .Index(t => t.IdProduto);
            
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
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.logId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estadoes", "Estado_IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Ventas", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.DetalleVentas", "IdVenta", "dbo.Ventas");
            DropForeignKey("dbo.Inventarios", "IdProduto", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.DetalleVentas", "IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.Compras", "IdProducto", "dbo.Productoes");
            DropForeignKey("dbo.Compras", "IdCPComprar", "dbo.ComprarProductoes");
            DropForeignKey("dbo.Productoes", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Ventas", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Rols");
            DropForeignKey("dbo.Registroes", "IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Empleadoes", "Usuario_IdUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Registroes", "IdRol", "dbo.Rols");
            DropForeignKey("dbo.Rols", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Registroes", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Registroes", "IdCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "IdEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Categorias", "IdEstado", "dbo.Estadoes");
            DropIndex("dbo.Inventarios", new[] { "IdProduto" });
            DropIndex("dbo.Compras", new[] { "IdCPComprar" });
            DropIndex("dbo.Compras", new[] { "IdProducto" });
            DropIndex("dbo.Productoes", new[] { "IdCategoria" });
            DropIndex("dbo.Productoes", new[] { "IdEstado" });
            DropIndex("dbo.DetalleVentas", new[] { "IdVenta" });
            DropIndex("dbo.DetalleVentas", new[] { "IdProducto" });
            DropIndex("dbo.Ventas", new[] { "IdUsuario" });
            DropIndex("dbo.Ventas", new[] { "IdCliente" });
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropIndex("dbo.Usuarios", new[] { "IdEstado" });
            DropIndex("dbo.Rols", new[] { "IdEstado" });
            DropIndex("dbo.Empleadoes", new[] { "Usuario_IdUsuario" });
            DropIndex("dbo.Empleadoes", new[] { "IdEstado" });
            DropIndex("dbo.Registroes", new[] { "IdRol" });
            DropIndex("dbo.Registroes", new[] { "IdUsuario" });
            DropIndex("dbo.Registroes", new[] { "IdEmpleado" });
            DropIndex("dbo.Registroes", new[] { "IdCliente" });
            DropIndex("dbo.Clientes", new[] { "IdEstado" });
            DropIndex("dbo.Estadoes", new[] { "Estado_IdEstado" });
            DropIndex("dbo.Categorias", new[] { "IdEstado" });
            DropTable("dbo.Logs");
            DropTable("dbo.Empresas");
            DropTable("dbo.Inventarios");
            DropTable("dbo.ComprarProductoes");
            DropTable("dbo.Compras");
            DropTable("dbo.Productoes");
            DropTable("dbo.DetalleVentas");
            DropTable("dbo.Ventas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Rols");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Registroes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Categorias");
        }
    }
}
