using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.DAL
{
    public class ServicioUsuario
    {
        public void CrearUsuario(NuevoUsuario usuario)
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;


            SqlCommand comando = new SqlCommand("CrearUsuario", conection);
            comando.CommandType = (CommandType.StoredProcedure);
            comando.Parameters.Add(new SqlParameter("@name", usuario.Name));
            comando.Parameters.Add(new SqlParameter("@pass", usuario.Contrasena));
            comando.Parameters.Add(new SqlParameter("@enable", usuario.Enable));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();

        }
        public void EliminarUsuario(UsuarioGenerico usuario)
        {

            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;

            SqlCommand comando = new SqlCommand("EliminarUsuario", conection);
            comando.CommandType = (CommandType.StoredProcedure);
            comando.Parameters.Add(new SqlParameter("@ID", usuario.Id));
            conection.Open();
            comando.ExecuteNonQuery();
            conection.Close();

        }

      public  List<UsuarioGenerico> ListarUsuario()
        {
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;
            SqlCommand comando = new SqlCommand("ListarUsuario", conection);
            comando.CommandType = (CommandType.StoredProcedure);
            conection.Open();
            SqlDataReader reader = comando.ExecuteReader();
            List<UsuarioGenerico> usuarios = new List<UsuarioGenerico>();

            while (reader.Read())

            {
                UsuarioGenerico usuario = new UsuarioGenerico()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Contrasena = reader.GetString(2),
                    Enable = reader.GetBoolean(3)

                };

                usuarios.Add(usuario);
            }
            conection.Close();
            return usuarios;
       
        }

    }

}
