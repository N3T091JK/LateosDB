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
    public class CompraRealizadaDAL
    {

        private static CompraRealizadaDAL _instance;

        public static CompraRealizadaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompraRealizadaDAL();
                }
                return _instance;

            }


        }
      

        public List<CompraRealizada> SellectAll()
        {
            List<CompraRealizada> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.CompraRealizadas.Include(x => x.Facturas).ToList();
                result = _context.CompraRealizadas.Include(x => x.DetalleFactura).ToList();
            }

            return result;


        }
        public CompraRealizada SellectById(int id)
        {
            CompraRealizada result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.CompraRealizadas
                    .FirstOrDefault(x => x.IdComprar == id);
            }

            return result;


        }

        public List<CompraRealizada> SellecProductotById(int id)
        {
            List<CompraRealizada> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.CompraRealizadas.Where(x => x.IdComprar.Equals(id)).ToList();
            }

            return result;


        }

        public bool Insert(CompraRealizada entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.CompraRealizadas.FirstOrDefault(x => x.IdComprar.Equals(entity.IdComprar));
                if (query == null)
                {
                    _context.CompraRealizadas.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(CompraRealizada entity)
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
                var query = _context.CompraRealizadas.FirstOrDefault(x => x.IdComprar == id);
                if (query != null)
                {
                    _context.CompraRealizadas.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }

    }
}
