using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class VentaBL
    {
        private static VentaBL _instance;

        public static VentaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VentaBL();

                return _instance;
            }
        }
        public bool Insert(Ventas entity, List<DetalleVentas> detalles)
        {
            bool result = false;
            try
            {
                result = VentaDAL.Instance.Insert(entity);
                for (int i = 0; i< detalles.Count; i++)
                {
                    detalles[i].IdVenta = entity.IdVenta;
                }

                result = DetallesVentasBL.Instance.Insert(detalles);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public List<Ventas> SellecALL()
        {
            List<Ventas> result;
            try
            {
                result = VentaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }


    }
}
