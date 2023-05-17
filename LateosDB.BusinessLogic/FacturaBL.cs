using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class FacturaBL
    {
        private static FacturaBL _instance;

        public static FacturaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FacturaBL();

                return _instance;
            }
        }

        public List<Factura> SellecALL()
        {
            List<Factura> result;
            try
            {
                result = FacturaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Insert(Factura entity)
        {
            bool result = false;
            try
            {
                result = FacturaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }
        public bool Update(Factura entity)
        {
            bool result = false;
            try
            {
                result = FacturaDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
