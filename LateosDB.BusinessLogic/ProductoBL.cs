using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class ProductoBL
    {
        private static ProductoBL _instance;

        public static ProductoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductoBL();

                return _instance;
            }
        }

        public List<Producto> SellecALL()
        {
            List<Producto> result;
            try
            {
                result = ProductoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Insert(Producto entity)
        {
            bool result = false;
            try
            {
                result = ProductoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Producto entity)
        {
            bool result = false;
            try
            {
                result = ProductoDAL.Instance.Update(entity);
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
                result = ProductoDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
