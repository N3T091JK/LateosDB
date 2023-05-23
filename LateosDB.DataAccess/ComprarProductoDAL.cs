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
    public class ComprarProductoDAL
    {


        private static ComprarProductoDAL _instance;

        public static ComprarProductoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ComprarProductoDAL();
                }
                return _instance;

            }


        }

        public List<CompraProducto> SellectAll()
        {
            List<CompraProducto> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.compraProductos.ToList();
            }

            return result;


        }

        public CompraProducto SellectById(int id)
        {
            CompraProducto result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.compraProductos
                    .FirstOrDefault(x => x.IdCompraProducto == id);
            }

            return result;
        }

        public bool Insert(CompraProducto entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.compraProductos.FirstOrDefault(x => x.IdCompraProducto.Equals(entity.IdCompraProducto));
                if (query == null)
                {
                    _context.compraProductos.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }







        public bool Update(CompraProducto entity)
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
                var query = _context.compraProductos.FirstOrDefault(x => x.IdCompraProducto == id);
                if (query != null)
                {
                    _context.compraProductos.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }



    }
}
