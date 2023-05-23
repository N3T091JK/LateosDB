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
    public class FacturaDAL
    {


        private static FacturaDAL _instance;

        public static FacturaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FacturaDAL();
                }
                return _instance;

            }
        }


        public List<Factura> SellectAll()
        {
            List<Factura> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.facturas.Include(x => x.Clientes).ToList();
                result = _context.facturas.Include(x => x.Usuarios).ToList();
                result = _context.facturas.Include(x => x.Descuentos).ToList();
            }
            return result;
        }

        public Factura SellectById(int id)
        {
            Factura result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.facturas
                    .FirstOrDefault(x => x.IdFactura == id);
            }

            return result;


        }


        public bool Insert(Factura entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.facturas.FirstOrDefault(x => x.IdFactura.Equals(entity.IdFactura));
                if (query == null)
                {
                    _context.facturas.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }


        public bool Update(Factura entity)
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
                var query = _context.facturas.FirstOrDefault(x => x.IdFactura == id);
                if (query != null)
                {
                    _context.facturas.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }







    }
}
