using LateosDB.Entities;
using LateosDB.Entities.AppContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.DataAccess
{
    public class EstadoDAL
    {
        private static EstadoDAL _instance;

        public static EstadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EstadoDAL();
                }
                return _instance;

            }


        }

        public List<Estado> SellectAll()
        {
            List<Estado> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.estados.ToList();
            }

            return result;


        }

        public Estado SellectById(int id)
        {
            Estado result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.estados
                    .FirstOrDefault(x => x.IdEstado == id);
            }

            return result;
        }

        public bool Insert(Estado entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.estados.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.estados.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }






        public bool Update(Estado entity)
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
                var query = _context.estados.FirstOrDefault(x => x.IdEstado == id);
                if (query != null)
                {
                    _context.estados.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }



    }
}
