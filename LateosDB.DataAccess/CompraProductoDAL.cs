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
    public class CompraProductoDAL
    {
        private static CompraProductoDAL _instance;

        public static CompraProductoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompraProductoDAL();
                }
                return _instance;

            }


        }


        public List<ComprarProducto> SellectAll()
        {
            List<ComprarProducto> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.comprarProductos.Include(x => x.Compras).ToList();
            }

            return result;


        }
        public ComprarProducto SellectById(int id)
        {
            ComprarProducto result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.comprarProductos
                    .FirstOrDefault(x => x.IdCPComprar == id);
            }

            return result;


        }

        public List<ComprarProducto> SellecProductotById(int id)
        {
            List<ComprarProducto> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.comprarProductos.Where(x => x.IdCPComprar.Equals(id)).ToList();
            }

            return result;


        }

        public bool Insert(ComprarProducto entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                _context.comprarProductos.Add(entity);
                result = _context.SaveChanges() > 0;



                return result;

            }
        }

        public bool Update(ComprarProducto entity)
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
