using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class EstadoBL
    {
        private static EstadoBL _instance;

        public static EstadoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EstadoBL();

                return _instance;
            }
        }

        public List<Estado> SellecALL()
        {
            List<Estado> result;
            try
            {
                result = EstadoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Estado entity)
        {
            bool result = false;
            try
            {
                result = EstadoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Estado entity)
        {
            bool result = false;
            try
            {
                 result = EstadoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
