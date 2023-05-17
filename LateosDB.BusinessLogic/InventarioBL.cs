using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class InventarioBL
    {
        private static InventarioBL _instance;

        public static InventarioBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InventarioBL();

                return _instance;
            }
        }

        public List<Inventario> SellecALL()
        {
            List<Inventario> result;
            try
            {
                result = InventarioDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Inventario entity)
        {
            bool result = false;
            try
            {
                result = InventarioDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Inventario entity)
        {
            bool result = false;
            try
            {
                result = InventarioDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }






    }
}
