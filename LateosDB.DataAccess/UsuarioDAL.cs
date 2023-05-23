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
    public class UsuarioDAL
    {
        private static UsuarioDAL _instance;

        public static UsuarioDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioDAL();
                }
                return _instance;

            }
        }

        public List<Usuario> SellectAll()
        {
            List<Usuario> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.usuarios.Include(x => x.Rols).ToList();
            }

            return result;


        }



        //public List<Registro> SellecRegistroById(int id)
        //{
        //    List<Registro> result = null;
        //    using (AppDBLateosContext _context = new AppDBLateosContext())
        //    {
        //        result = _context.Registros.Where(x => x.IdUsuario.Equals(id)).ToList();
        //    }
        //    return result;
        //}


   

        public List<Factura> SellecFacturaById(int id)
        {
            List<Factura> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.facturas.Where(x => x.IdUsuario.Equals(id)).ToList();
            }

            return result;


        }



        public Usuario SellectById(int id)
        {
            Usuario result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.usuarios
                    .FirstOrDefault(x => x.IdUsuario == id);
            }
            return result;
        }

        public bool Insert(Usuario entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.usuarios.FirstOrDefault(x => x.IdUsuario.Equals(entity.IdUsuario));
                if (query == null)
                {
                    _context.usuarios.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }


        public bool Update(Usuario entity)
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
                var query = _context.usuarios.FirstOrDefault(x => x.IdUsuario == id);
                if (query != null)
                {
                    _context.usuarios.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }



    }
}
