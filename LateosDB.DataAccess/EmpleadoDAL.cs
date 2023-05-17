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
    public class EmpleadoDAL
    {
        private static EmpleadoDAL _instance;

        public static EmpleadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpleadoDAL();
                }
                return _instance;

            }


        }

        public List<Empleado> SellectAll()
        {
            List<Empleado> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.empleados.Include(x => x.Estado).ToList();
            }

            return result;


        }
        public Empleado SellectById(int id)
        {
            Empleado result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.empleados
                    .FirstOrDefault(x => x.IdEmpleado == id);
            }

            return result;


        }



        public bool Insert(Empleado entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.empleados.FirstOrDefault(x => x.IdEmpleado.Equals(entity.IdEmpleado));
                if (query == null)
                {
                    _context.empleados.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }
        }

        public bool Update(Empleado entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                var query = _context.empleados.FirstOrDefault(x => x.IdEmpleado.Equals(entity.IdEmpleado));


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
