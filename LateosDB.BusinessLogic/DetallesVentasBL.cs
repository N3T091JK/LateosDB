using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class DetallesVentasBL
    {

        private static DetallesVentasBL _instance;

        public static DetallesVentasBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DetallesVentasBL();

                return _instance;
            }
        }
        public bool Insert(List<DetalleVentas> entity)
        {
            bool result = false;
            try
            {
                result = DetalleVentasDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public List<DetalleVentas> SellecALL()
        {
            List<DetalleVentas> result;
            try
            {
                result = DetalleVentasDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }



    }
    }
