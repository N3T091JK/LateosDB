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
    public class LogDAL
    {

        //CAMBIAR LA BASE DE DATOS A NOMBRE LOGINE
        //si da problema hay que cambiarse
        private static LogDAL _instance;

        public static LogDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogDAL();
                }
                return _instance;

            }


        }

        public List<Log> SellectAll()
        {
            List<Log> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Logs.ToList();
            }

            return result;


        }

        public Log SellectById(int id)
        {
            Log result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.Logs
                    .FirstOrDefault(x => x.logId == id);
            }

            return result;


        }
        public bool Insert(Log entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.Logs
                    .FirstOrDefault(x => x.Fecha.Equals(entity.Fecha)
                    );
                if (query == null)
                {
                    _context.Logs.Add(entity);
                    result = _context.SaveChanges() > 0;


                }
                return result;

            }

        }

    }
}
