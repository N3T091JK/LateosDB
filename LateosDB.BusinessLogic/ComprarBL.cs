using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class ComprarBL
    {
        private static ComprarBL _instance;

        public static ComprarBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ComprarBL();

                return _instance;
            }
        }
        public bool Insert(List<Compra> entity)
        {
            bool result = false;
            try
            {
                result = ComprarDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public List<Compra> SellecALL()
        {
            List<Compra> result;
            try
            {
                result = ComprarDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Update(Compra entity)
        {
            bool result = false;
            try
            {
                result = ComprarDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = ComprarDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }


    }
}
