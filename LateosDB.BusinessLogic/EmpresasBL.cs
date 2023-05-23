using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class EmpresasBL
    {
        private static EmpresasBL _instance;

        public static EmpresasBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmpresasBL();

                return _instance;
            }
        }

        public List<Empresa> SellecALL()
        {
            List<Empresa> result;
            try
            {
                result = EmpresaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Empresa entity)
        {
            bool result = false;
            try
            {
                result = EmpresaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }
        public bool Update(Empresa entity)
        {
            bool result = false;
            try
            {
                result = EmpresaDAL.Instance.Update(entity);
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
                result = EmpresaDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
