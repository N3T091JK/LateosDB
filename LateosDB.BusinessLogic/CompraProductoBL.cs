using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class CompraProductoBL
    {

        private static CompraProductoBL _instance;

        public static CompraProductoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CompraProductoBL();

                return _instance;
            }
        }

        public List<CompraProducto> SellecALL()
        {
            List<CompraProducto> result;
            try
            {
                result = ComprarProductoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(CompraProducto entity)
        {
            bool result = false;
            try
            {
                result = ComprarProductoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(CompraProducto entity)
        {
            bool result = false;
            try
            {
                result = ComprarProductoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
