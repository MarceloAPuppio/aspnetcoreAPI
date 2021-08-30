using EL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DALUsuario : ICRUD<Usuario>
    {
        public DALUsuario()
        {
        }

        public int Login(string password, string nombre)
        {
            using var Connection = new SqlConnection(DATOS.ConnectionString);
            string query = "select * from usuario where Nombre=@Nombre and Password =@Password";
            using var Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Nombre", nombre);
            Command.Parameters.AddWithValue("@Password", password);
            Connection.Open();
            using (var DataReader = Command.ExecuteReader())
            {

            if (!DataReader.Read()) return 0;
            }
            return int.Parse(Command.ExecuteScalar().ToString());

        }
        public int Create(Usuario obj)
        {
            using var Connection = new SqlConnection(DATOS.ConnectionString);
            string query = "insert into usuario (Nombre, Password) values(@Nombre, @Password)";    
                using var Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@Nombre", obj.Nombre);
                Command.Parameters.AddWithValue("@Password", obj.Password);
                Connection.Open();
                return Command.ExecuteNonQuery();

        }

        public int Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ReadAll()
        {
            using var Connection = new SqlConnection(DATOS.ConnectionString);
            using var Commnad = new SqlCommand("select * from usuario", Connection);
            Connection.Open();
            using var DataReader = Commnad.ExecuteReader();
            var usuarios = new List<Usuario>();
            while (DataReader.Read())
            {
                var usuario = new Usuario() { ID = int.Parse(DataReader["ID"].ToString()), Nombre = DataReader["Nombre"].ToString() };
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public Usuario ReadOne(int ID)
        {
            using var Connection = new SqlConnection(DATOS.ConnectionString);
            string query = "select * from usuario where id = @ID";
            using var Command = new SqlCommand(query, Connection);
                    Command.Parameters.AddWithValue("@ID", ID);
                    Connection.Open();
                    using var dataReader = Command.ExecuteReader();
                            if (dataReader.Read()) {
                return new Usuario()
                {
                    ID = int.Parse(dataReader["ID"].ToString()),
                    Nombre = dataReader["Nombre"].ToString()
                    //Password= dataReader["Password"].ToString()

                            };
                                }
            return new Usuario();
        }

        public int Update(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
