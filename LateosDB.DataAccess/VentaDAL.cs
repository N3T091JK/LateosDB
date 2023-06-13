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
    public class VentaDAL
    {

        private static VentaDAL _instance;

        public static VentaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VentaDAL();
                }
                return _instance;

            }


        }


        public List<Ventas> SellectAll()
        {
            List<Ventas> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.ventas.Include(x => x.Cliente).ToList();
                result = _context.ventas.Include(x => x.Usuario).ToList();
            }

            return result;


        }
        public Ventas SellectById(int id)
        {
            Ventas result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.ventas
                    .FirstOrDefault(x => x.IdVenta == id);
            }

            return result;


        }

        public List<Ventas> SellecProductotById(int id)
        {
            List<Ventas> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.ventas.Where(x => x.IdVenta.Equals(id)).ToList();
            }

            return result;


        }

        public bool Insert(Ventas entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                
                    _context.ventas.Add(entity);
                    result = _context.SaveChanges() > 0;

                

                return result;

            }
        }

        public bool Update(Ventas entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            return result;
        }
    }
}
