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
    public class DescuentoDAL
    {
        private static DescuentoDAL _instance;

        public static DescuentoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DescuentoDAL();
                }
                return _instance;

            }


        }

        public List<Descuento> SellectAll()
        {
            List<Descuento> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.descuentos.ToList();
            }

            return result;


        }

        public Descuento SellectById(int id)
        {
            Descuento result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.descuentos
                    .FirstOrDefault(x => x.IdDescuento == id);
            }

            return result;
        }

        public bool Insert(Descuento entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.descuentos.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.descuentos.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }
        public bool Update(Descuento entity)
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
                var query = _context.descuentos.FirstOrDefault(x => x.IdDescuento == id);
                if (query != null)
                {
                    _context.descuentos.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
    }
}
