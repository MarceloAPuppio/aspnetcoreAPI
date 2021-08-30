using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EL;
namespace DAL
{
    public class DALUsuarioRol : ICRUD<UsuarioRol>
    {
        public int Create(UsuarioRol obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioRol> ReadAll()
        {
            throw new NotImplementedException();
        }
        public List<Rol> ReadAllByUsuario(int ID)
        {
            List<Rol> UsuarioRoles;
            using var Connection = new SqlConnection(DATOS.ConnectionString);
            string query = "select R.Nombre, R.ID from UsariosRoles as UR inner join Roles as R on ur.IDRol = R.ID where UR.IDUsuario = @IDUsuario";
                using var Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@IDUsuario", ID);
                Connection.Open();
                using var DataReader = Command.ExecuteReader();
                    UsuarioRoles = new List<Rol>();
                    while (DataReader.Read())
                    {
                        UsuarioRoles.Add(new Rol() { ID= int.Parse(DataReader["ID"].ToString()), Nombre= DataReader["Nombre"].ToString() });
                    }
            return UsuarioRoles;
                    
        }

        public UsuarioRol ReadOne(int ID)
        {
            throw new NotImplementedException();
        }

        public int Update(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
