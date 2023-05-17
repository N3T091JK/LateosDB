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
    public class ClienteDAL
    {
        private static ClienteDAL _instance;

        public static ClienteDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClienteDAL();
                }
                return _instance;

            }
        }

        public List<Cliente> SellectAll()
        {
            List<Cliente> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.clientes.Include(x => x.Estado).ToList();
            }

            return result;


        }



        //public List<Registro> SellecRegistroById(int id)
        //{
        //    List<Registro> result = null;
        //    using (AppDBLateosContext _context = new AppDBLateosContext())
        //    {
        //        result = _context.Registros.Where(x => x.IdCliente.Equals(id)).ToList();
        //    }
        //    return result;
        //}

        public List<Factura> SellecFacturaById(int id)
        {
            List<Factura> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.facturas.Where(x => x.IdCliente.Equals(id)).ToList();
            }

            return result;


        }






        public Cliente SellectById(int id)
        {
            Cliente result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.clientes
                    .FirstOrDefault(x => x.IdCliente == id);
            }
            return result;
        }

        public bool Insert(Cliente entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.clientes.FirstOrDefault(x => x.IdCliente.Equals(entity.IdCliente));
                if (query == null)
                {
                    _context.clientes.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }

        public bool Update(Cliente entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                var query = _context.clientes.FirstOrDefault(x => x.IdCliente.Equals(entity.IdCliente));


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
