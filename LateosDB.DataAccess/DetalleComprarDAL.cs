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
    public class DetalleComprarDAL
    {
        private static DetalleComprarDAL _instance;

        public static DetalleComprarDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetalleComprarDAL();
                }
                return _instance;

            }


        }

        public List<DetalleCompra> SellectAll()
        {
            List<DetalleCompra> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.detalleCompras.Include(x => x.CompraProductos).ToList();
            }

            return result;


        }
        public DetalleCompra SellectById(int id)
        {
            DetalleCompra result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.detalleCompras
                    .FirstOrDefault(x => x.IdDetalleCompra == id);
            }

            return result;


        }

       

        public bool Insert(DetalleCompra entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.detalleCompras.FirstOrDefault(x => x.IdDetalleCompra.Equals(entity.IdDetalleCompra));
                if (query == null)
                {
                    _context.detalleCompras.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(DetalleCompra entity)
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
                var query = _context.detalleCompras.FirstOrDefault(x => x.IdDetalleCompra == id);
                if (query != null)
                {
                    _context.detalleCompras.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }

    }
}
