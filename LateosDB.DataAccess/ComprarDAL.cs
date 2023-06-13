using LateosDB.Entities.AppContext;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.DataAccess
{
    public class ComprarDAL
    {
        private static ComprarDAL _instance;

        public static ComprarDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ComprarDAL();
                }
                return _instance;

            }
        }
        public List<Compra> SellectAll()
        {
            List<Compra> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Compras.Include(x => x.Producto).ToList();
                result = _context.Compras.Include(x => x.ComprarProductos).ToList();

            }
            return result;
        }



        public Compra SellectById(int id)
        {
            Compra result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Compras
                    .FirstOrDefault(x => x.IdCompraProducto == id);
            }
            return result;
        }

        public bool Insert(List<Compra> entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                foreach (var item in entity)
                {
                    _context.Compras.Add(item);
                    var query = InventarioDAL.Instance.SellectById(item.IdProducto);

                    Inventario _inventario = new Inventario()
                    {
                        IdInventario = query.IdInventario,
                        IdProduto = query.IdProduto,
                        cantidad = query.cantidad + item.Cantidad
                    };
                    InventarioDAL.Instance.Update(_inventario);
                }
                //result = _context.SaveChanges() > 0;
                return result;

            }

        }
        public bool Update(Compra entity)
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
                var query = _context.Compras.FirstOrDefault(x => x.IdCompraProducto == id);
                if (query != null)
                {
                    _context.Compras.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }

    }
}
