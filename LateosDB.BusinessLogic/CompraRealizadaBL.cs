using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class CompraRealizadaBL
    {
        private static CompraRealizadaBL _instance;

        public static CompraRealizadaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CompraRealizadaBL();

                return _instance;
            }
        }

        public List<CompraRealizada> SellecALL()
        {
            List<CompraRealizada> result;
            try
            {
                result = CompraRealizadaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Insert(CompraRealizada entity)
        {
            bool result = false;
            try
            {
                result = CompraRealizadaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(CompraRealizada entity)
        {
            bool result = false;
            try
            {
                result = CompraRealizadaDAL.Instance.Update(entity);
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
                result = CompraRealizadaDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
