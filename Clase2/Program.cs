using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Clase2.DAL;

namespace Clase2
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection conection = new SqlConnection();
            ////conection.ConnectionString = "Data source=localhost;" +
            ////"Initial Catalog=Tienda;" + "Integrated Security=SSPI";
            //conection.ConnectionString = ConfigurationManager.ConnectionStrings["Tienda"].ConnectionString;


            ////SqlCommand comando = new SqlCommand("CrearProducto", conection);
            ////comando.CommandType = (CommandType.StoredProcedure);
            ////comando.Parameters.Add(new SqlParameter("@nombre", "Producto 1"));
            ////comando.Parameters.Add(new SqlParameter("@cantidad",10));
            ////comando.Parameters.Add(new SqlParameter("@stockActual", 20));
            ////conection.Open();
            ////comando.ExecuteNonQuery();
            //SqlCommand comando = new SqlCommand("ListarProductos", conection);
            //comando.CommandType = (CommandType.StoredProcedure);
            //conection.Open();
            //SqlDataReader lectorDatos = comando.ExecuteReader();


            //while (lectorDatos.Read())
            //{
            //    Console.WriteLine("{0}", lectorDatos.GetString(1));
            //}
            //Console.ReadLine();




            ServicioUsuario servicioUsuario = new ServicioUsuario();
            NuevoUsuario usuario = new NuevoUsuario();
            usuario.Name = "cazzia";
            usuario.Contrasena = "123";
            usuario.Enable = false;
            servicioUsuario.CrearUsuario(usuario);

            Console.WriteLine($"Usuario Insertado {usuario.Name},{usuario.Contrasena}, {usuario.Enable} ");
            Console.ReadLine();



            //ServicioUsuario servicio = new ServicioUsuario();
            //servicio.ListarUsuario().ForEach(x => Console.WriteLine($"{x.Id} , {x.Name}, {x.Contrasena}, {x.Enable}"));
            //Console.ReadKey();

            ServicioUsuario eliminarUsuario = new ServicioUsuario();
            UsuarioGenerico usuNuevo = new UsuarioGenerico();
            usuNuevo.Id = 5;
            eliminarUsuario.EliminarUsuario(usuNuevo);
            Console.WriteLine($"Id del Usuario a Eliminar {usuNuevo.Id}");
            Console.ReadKey();


        }
    }
}
