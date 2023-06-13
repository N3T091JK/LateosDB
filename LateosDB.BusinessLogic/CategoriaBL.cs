using LateosDB.Entities;
using LateosDB.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class CategoriaBL
    {
        private static CategoriaBL _instance;

        public static CategoriaBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoriaBL();

                return _instance;
            }
        }

        public List<Categoria> SellecALL()
        {
            List<Categoria> result;
            try
            {
                result = CategoriaDAL.Instance.SellectAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool Insert(Categoria entity)
        {
            bool result = false;
            try
            {
                result = CategoriaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return result;
        }

        public bool Update(Categoria entity)
        {
            bool result = false;
            try
            {
                result = CategoriaDAL.Instance.Update(entity);
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
                result = CategoriaDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }



    }
}
