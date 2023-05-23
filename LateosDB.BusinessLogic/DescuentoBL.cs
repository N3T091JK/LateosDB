using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class DescuentoBL
    {
        private static DescuentoBL _instance;

        public static DescuentoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DescuentoBL();

                return _instance;
            }
        }

        public List<Descuento> SellecALL()
        {
            List<Descuento> result;
            try
            {
                result = DescuentoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Insert(Descuento entity)
        {
            bool result = false;
            try
            {
                result = DescuentoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Descuento entity)
        {
            bool result = false;
            try
            {
                result = DescuentoDAL.Instance.Update(entity);
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
                result = DescuentoDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
