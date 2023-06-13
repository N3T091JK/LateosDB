using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class RolBL
    {
        private static RolBL _instance;

        public static RolBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RolBL();

                return _instance;
            }
        }

        public List<Rol> SellecALL()
        {
            List<Rol> result;
            try
            {
                result = RolDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Rol entity)
        {
            bool result = false;
            try
            {
                result = RolDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Rol entity)
        {
            bool result = false;
            try
            {
                result = RolDAL.Instance.Update(entity);
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
                result = RolDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
