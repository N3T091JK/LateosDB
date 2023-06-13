using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class ComprarProductoBL
    {
        private static ComprarProductoBL _instance;

        public static ComprarProductoBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ComprarProductoBL();

                return _instance;
            }
        }
        public bool Insert(ComprarProducto entity, List<Compra> detalles)
        {
            bool result = false;
           
                result = CompraProductoDAL.Instance.Insert(entity);
                for (int i = 0; i < detalles.Count; i++)
                {
                    detalles[i].IdCPComprar = entity.IdCPComprar;
                }

                result = ComprarDAL.Instance.Insert(detalles);
           
            return result;
        }

        public List<ComprarProducto> SellecALL()
        {
            List<ComprarProducto> result;
            try
            {
                result = CompraProductoDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }


    }
}
