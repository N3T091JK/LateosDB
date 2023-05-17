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
    public class DetalleFacturaDAL
    {
        private static DetalleFacturaDAL _instance;

        public static DetalleFacturaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetalleFacturaDAL();
                }
                return _instance;

            }


        }

        public List<DetalleFactura> SellectAll()
        {
            List<DetalleFactura> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.detalleFacturas.Include(x => x.Productos).ToList();
            }

            return result;


        }

        public DetalleFactura SellectById(int id)
        {
            DetalleFactura result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.detalleFacturas
                    .FirstOrDefault(x => x.IdDetalleFactura == id);
            }

            return result;


        }

        public bool Insert(DetalleFactura entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.detalleFacturas.FirstOrDefault(x => x.IdDetalleFactura.Equals(entity.IdDetalleFactura));
                if (query == null)
                {
                    _context.detalleFacturas.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(DetalleFactura entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                var query = _context.detalleFacturas.FirstOrDefault(x => x.IdDetalleFactura.Equals(entity.IdDetalleFactura));


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
