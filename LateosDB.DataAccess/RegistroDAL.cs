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
    public class RegistroDAL
    {



        private static RegistroDAL _instance;

        public static RegistroDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RegistroDAL();
                }
                return _instance;

            }
        }


        public List<Registro> SellectAll()
        {
            List<Registro> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Registros.Include(x => x.Cliente).ToList();
                result = _context.Registros.Include(x => x.Empleado).ToList();
                result = _context.Registros.Include(x => x.Usuarios).ToList();
                result = _context.Registros.Include(x => x.Rols).ToList();
                //result = _context.Registros.Include(x => x.Empresa).ToList();


            }
            return result;
        }


        public Registro SellectById(int id)
        {
            Registro result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Registros
                    .FirstOrDefault(x => x.IdRegistro == id);
            }

            return result;


        }


        public bool Insert(Registro entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.Registros.FirstOrDefault(x => x.IdRegistro.Equals(entity.IdRegistro));

                if (query == null)
                {
                    _context.Registros.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }


        public bool Update(Registro entity)
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
                var query = _context.Registros.FirstOrDefault(x => x.IdRegistro == id);
                if (query != null)
                {
                    _context.Registros.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }








    }
}
