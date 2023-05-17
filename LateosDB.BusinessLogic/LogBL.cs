using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class LogBL
    {
        private static LogBL _instance;

        public static LogBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogBL();

                return _instance;
            }
        }

        public List<Log> SellecALL()
        {
            List<Log> result;
            try
            {
                result = LogDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Log entity)
        {
            bool result = false;
            try
            {
                result = LogDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Log entity)
        {
            bool result = false;
            try
            {
                result = LogDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
