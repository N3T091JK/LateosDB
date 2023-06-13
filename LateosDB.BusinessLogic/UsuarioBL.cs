using LateosDB.DataAccess;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateosDB.BusinessLogic
{
    public class UsuarioBL
    {
        private static UsuarioBL _instance;

        public static UsuarioBL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UsuarioBL();

                return _instance;
            }
        }
        public List<Usuario> SelectAll()
        {
            List<Usuario> result;
            try
            {
                result = UsuarioDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                new Exception(ex.ToString());
                throw new Exception(ex.Message);
            }

            return result;

        }

        public bool Insert(Usuario entity)
        {
            bool result = false;
            try
            {
                result = UsuarioDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                new Exception(ex.ToString());
                throw new Exception(ex.Message);
            }

            return result;

        }
        public bool Update(Usuario entity)
        {
            bool result = false;
            try
            {
                result = UsuarioDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }
            return result;
        }
        //bl para el login
        public Usuario Login(string Email, string Password)
        {

            try
            {
                return null;// UsuarioDAL.Instance.Login(Email, Password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error. " + ex.Message);
            }


        }
        public bool Delete(int id)
        {

            bool result = false;
            try
            {
                result = UsuarioDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error. " + ex.Message);
            }

            return result;
        }

    }
}
