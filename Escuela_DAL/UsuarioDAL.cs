using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL
{
    public class UsuarioDAL
    {
        public DataTable consultarUsuario(string nombre, string contraseña)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString= @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_consultarUsuario";
            command.Connection = connection;

            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pContraseña", contraseña);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtUsuario = new DataTable();

            connection.Open();
            adapter.SelectCommand = command;
            adapter.Fill(dtUsuario);

            connection.Close();

            return dtUsuario;
        }
    }
}
