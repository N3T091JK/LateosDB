using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class RegistroBL
    {
        private static RegistroBL _instance;

        public static RegistroBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RegistroBL();

                return _instance;
            }
        }

        public List<Registro> SellecALL()
        {
            List<Registro> result;
            try
            {
                result = RegistroDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Registro entity)
        {
            bool result = false;
            try
            {
                result = RegistroDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Registro entity)
        {
            bool result = false;
            try
            {
                result = RegistroDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
