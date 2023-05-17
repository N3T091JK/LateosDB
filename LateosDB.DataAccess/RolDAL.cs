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
    public class RolDAL
    {

        private static RolDAL _instance;

        public static RolDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RolDAL();
                }
                return _instance;

            }


        }

        public List<Rol> SellectAll()
        {
            List<Rol> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Rols.Include(x => x.Estado).ToList();
            }

            return result;


        }

        public Rol SellectById(int id)
        {
            Rol result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Rols
                    .FirstOrDefault(x => x.IdRol == id);
            }

            return result;
        }

        public List<Usuario> SellecUsuarioById(int id)
        {
            List<Usuario> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.usuarios.Where(x => x.IdRol.Equals(id)).ToList();
            }

            return result;


        }

        //public List<Registro> SellecRegistroById(int id)
        //{
        //    List<Registro> result = null;
        //    using (AppDBLateosContext _context = new AppDBLateosContext())
        //    {
        //        result = _context.Registros.Where(x => x.IdRol.Equals(id)).ToList();
        //    }

        //    return result;


        //}



        public bool Insert(Rol entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.Rols.FirstOrDefault(x => x.IdRol.Equals(entity.IdRol));
                if (query == null)
                {
                    _context.Rols.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }



        public bool Update(Rol entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                var query = _context.Rols.FirstOrDefault(x => x.Roles.Equals(entity.Roles));


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
