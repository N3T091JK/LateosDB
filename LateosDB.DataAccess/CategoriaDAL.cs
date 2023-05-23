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
    public class CategoriaDAL
    {
        private static CategoriaDAL _instance;

        public static CategoriaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoriaDAL();
                }
                return _instance;

            }


        }

        public List<Categoria> SellectAll()
        {
            List<Categoria> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.categorias.Include(x => x.Estado).ToList();
            }

            return result;


        }
        public Categoria SellectById(int id)
        {
            Categoria result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.categorias
                    .FirstOrDefault(x => x.IdCategoria == id);
            }

            return result;


        }

        public List<Producto> SellecProductotById(int id)
        {
            List<Producto> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.productos.Where(x => x.IdCategoria.Equals(id)).ToList();
            }

            return result;


        }

        public bool Insert(Categoria entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.categorias.FirstOrDefault(x => x.Nombre.Equals(entity.Nombre));
                if (query == null)
                {
                    _context.categorias.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(Categoria entity)
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
                var query = _context.categorias.FirstOrDefault(x => x.IdCategoria == id);
                if (query != null)
                {
                    _context.categorias.Remove(query);
                    result = _context.SaveChanges() > 0;
                }
                return result;
            }

        }
    }
}
