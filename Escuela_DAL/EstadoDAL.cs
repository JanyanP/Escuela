using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL
{
    public class EstadoDAL
    {
        public DataTable cargarEstados()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarEstados";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtEstados = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtEstados);

            connection.Close();

            return dtEstados;
        }
    }
}
