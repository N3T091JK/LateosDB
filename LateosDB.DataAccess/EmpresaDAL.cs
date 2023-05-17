using LateosDB.Entities.AppContext;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.DataAccess
{
    public class EmpresaDAL
    {
        private static EmpresaDAL _instance;

        public static EmpresaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpresaDAL();
                }
                return _instance;
            }
        }

        public List<Empresa> SellectAll()
        {
            List<Empresa> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.empresas.ToList();
            }

            return result;
        }

        public Empresa SellectById(int id)
        {
            Empresa result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.empresas
                    .FirstOrDefault(x => x.IdEmpresa == id);
            }

            return result;
        }

        public bool Insert(Empresa entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.empresas.FirstOrDefault(x => x.IdEmpresa.Equals(entity.IdEmpresa));
                if (query == null)
                {
                    _context.empresas.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }



    }
}
