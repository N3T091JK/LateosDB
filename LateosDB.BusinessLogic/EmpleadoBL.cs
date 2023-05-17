using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class EmpleadoBL
    {
        private static EmpleadoBL _instance;

        public static EmpleadoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmpleadoBL();

                return _instance;
            }
        }

        public List<Empleado> SellecALL()
        {
            List<Empleado> result;
            try
            {
                result = EmpleadoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Insert(Empleado entity)
        {
            bool result = false;
            try
            {
                result = EmpleadoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Empleado entity)
        {
            bool result = false;
            try
            {
                result = EmpleadoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }


    }
}
