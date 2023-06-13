using LateosDB.Entities.AppContext;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LateosDB.DataAccess
{
    public class UsuarioDAL
    {
        private static UsuarioDAL _instance;

        public static UsuarioDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioDAL();
                }
                return _instance;

            }


        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.usuarios.Include(x => x.Rols).ToList();
                result = _context.usuarios.Include(x => x.Estados).ToList();

            }

            return result;


        }

        public Usuario SelectById(int id)
        {
            Usuario result = null;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                result = _context.usuarios
                    .FirstOrDefault(x => x.IdUsuario == id);
            }

            return result;


        }
        //public bool Insert(Usuario entity)
        //{

        //    bool result = false;
        //    using (AppDBLateosContext _context = new AppDBLateosContext())
        //    {
        //        var query = _context.usuarios
        //            .FirstOrDefault(x => x.Correo.Equals(entity.Correo));
        //        if (query == null)
        //        {
        //            var cmd = _context.Database.Connection.CreateCommand();
        //            cmd.CommandText = "UsuarioInsert";
        //            var param1 = cmd.CreateParameter();
        //            param1.ParameterName = "Correo";
        //            param1.Value = entity.Correo;
        //            var param2 = cmd.CreateParameter();
        //            param2.ParameterName = "Password";
        //            param2.Value = entity.Password;

        //            var param3 = cmd.CreateParameter();
        //            param3.ParameterName = "IdRol";
        //            param3.Value = entity.IdRol;

        //            var param4 = cmd.CreateParameter();
        //            param4.ParameterName = "IdEstado";
        //            param4.Value = entity.IdEstado;

        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.Add(param1);
        //            cmd.Parameters.Add(param2);
        //            cmd.Parameters.Add(param3);
        //            cmd.Parameters.Add(param4);
        //            _context.Database.Connection.Open();

        //            result = cmd.ExecuteNonQuery() > 0;

        //        }

        //        return result;

        //    }

        //}
        public bool Insert(Usuario entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                var query = _context.usuarios.FirstOrDefault(x => x.IdUsuario.Equals(entity.IdUsuario));
                if (query == null)
                {
                    _context.usuarios.Add(entity);
                    result = _context.SaveChanges() > 0;

                }

                return result;

            }

        }

        //public Usuario ComprobarUsuario(string email, string pwd)
        //{
        //    Usuario result = null;
        //    using (AppDBLateosContext _context = new AppDBLateosContext())
        //    {
        //        var cmd = _context.Database.Connection.CreateCommand();
        //        cmd.CommandText = "spLogin";
        //        var param1 = cmd.CreateParameter();
        //        param1.ParameterName = "Email";
        //        param1.Value = email;
        //        var param2 = cmd.CreateParameter();
        //        param2.ParameterName = "Password";
        //        param2.Value = pwd;
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.Add(param1);
        //        cmd.Parameters.Add(param2);
        //        _context.Database.Connection.Open();

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                result = new Usuario();
        //                result.IdUsuario = reader.GetInt32(0);
        //                result.Correo = reader.GetString(1);
        //                result.IdRol = reader.GetInt32(2);
        //            }
        //        }
        //    }

        //    return result;


        //}

        public bool Update(Usuario entity)
        {
            bool result = false;
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            return result;
        }
        public bool Delete(int Id)
        {
            using (AppDBLateosContext _context = new AppDBLateosContext())
            {

                bool result = false;

                var query = _context.usuarios.FirstOrDefault(x => x.IdUsuario == Id);
                if (query != null)
                {
                    _context.usuarios.Remove(query);
                    result = _context.SaveChanges() > 0;
                }

                return result;
            }

        }
       
    }
}
