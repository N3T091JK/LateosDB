using LateosDB.Entities.AppContext;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LateosDB.DataAccess
{
    public class DetalleVentasDAL
    {
        private static DetalleVentasDAL _instance;

        public static DetalleVentasDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetalleVentasDAL();
                }
                return _instance;

            }
        }
        public List<DetalleVentas> SellectAll()
        {
            List<DetalleVentas> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.detalleVentas.Include(x => x.Producto).ToList();
                result = _context.detalleVentas.Include(x => x.Ventas).ToList();
            
            }
            return result;
        }



        public DetalleVentas SellectById(int id)
        {
            DetalleVentas result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.detalleVentas
                    .FirstOrDefault(x => x.IdDetalleVenta == id);
            }
            return result;
        }

        public bool Insert(List<DetalleVentas> entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
               foreach(var item in entity)
                {
                    _context.detalleVentas.Add(item);
                    var query = InventarioDAL.Instance.SellectById(item.IdProducto);

                    Inventario _inventario = new Inventario()
                    {
                        IdInventario = query.IdInventario,
                        IdProduto = query.IdProduto,
                        cantidad = query.cantidad - item.Cantidad
                    };
                    InventarioDAL.Instance.Update(_inventario);
                }
                    result = _context.SaveChanges() > 0;
                return result;

            }

        }
        public bool Update(DetalleVentas entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            return result;
        }
        public bool Delete(int id)
        {
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                bool result = false;
                var query = _context.detalleVentas.FirstOrDefault(x => x.IdDetalleVenta == id);
                if (query != null)
                {
                    _context.detalleVentas.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }



    }
}
