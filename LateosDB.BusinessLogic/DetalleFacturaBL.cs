using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class DetalleFacturaBL
    {
        private static DetalleFacturaBL _instance;

        public static DetalleFacturaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DetalleFacturaBL();

                return _instance;
            }
        }

        public List<DetalleFactura> SellecALL()
        {
            List<DetalleFactura> result;
            try
            {
                result = DetalleFacturaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Insert(DetalleFactura entity)
        {
            bool result = false;
            try
            {
                result = DetalleFacturaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(DetalleFactura entity)
        {
            bool result = false;
            try
            {
                result = DetalleFacturaDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }

    }
}
