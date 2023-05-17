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
    public class InventarioDAL
    {

        private static InventarioDAL _instance;

        public static InventarioDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventarioDAL();
                }
                return _instance;

            }


        }

        public List<Inventario> SellectAll()
        {
            List<Inventario> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.inventarios.ToList();
            }

            return result;


        }

        public Inventario SellectById(int id)
        {
            Inventario result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.inventarios
                    .FirstOrDefault(x => x.IdInventario == id);
            }

            return result;
        }

        public bool Insert(Inventario entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.inventarios.FirstOrDefault(x => x.Stock.Equals(entity.Stock));
                if (query == null)
                {
                    _context.inventarios.Add(entity);
                    result = _context.SaveChanges() > 0;
                }
                return result;

            }

        }
        public List<Producto> SellecProductotById(int id)
        {
            List<Producto> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.productos.Where(x => x.IdProducto.Equals(id)).ToList();
            }

            return result;


        }
        public bool Update(Inventario entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                var query = _context.inventarios.FirstOrDefault(x => x.Stock.Equals(entity.Stock));


                if (query == null)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    result = _context.SaveChanges() > 0;

                }

                return result;
            }
        }





    }
}
