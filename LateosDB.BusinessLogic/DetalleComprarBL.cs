using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class DetalleComprarBL
    {
        private static DetalleComprarBL _instance;

        public static DetalleComprarBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DetalleComprarBL();

                return _instance;
            }
        }

        public List<DetalleCompra> SellecALL()
        {
            List<DetalleCompra> result;
            try
            {
                result = DetalleComprarDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(DetalleCompra entity)
        {
            bool result = false;
            try
            {
                result = DetalleComprarDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(DetalleCompra entity)
        {
            bool result = false;
            try
            {
                result = DetalleComprarDAL.Instance.Update(entity);
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
                result = DetalleComprarDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
    }
}
