using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL
{
    public class AlumnoDAL
    {

        EscuelaEntities modelo;

        public AlumnoDAL()
        {
            modelo = new EscuelaEntities();

        }

        /*
        public DataTable cargarAlumnos()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumnos";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumnos = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumnos);

            connection.Close();

            return dtAlumnos;

        }
        */

        public List<Object> cargarAlumnos()
        {
            var alumnos = from mAlumnos in modelo.Alumno
                          select new
                          {
                              matricula=mAlumnos.matricula,
                              nombre=mAlumnos.nombre,
                              fechaNacimiento=mAlumnos.fechaNacimiento,
                              semestre= mAlumnos.semestre,
                              nombreFacultad = mAlumnos.Facultad1.nombre,
                              nombreCiudad= mAlumnos.Ciudad1.nombre,
                          };
            return alumnos.AsEnumerable<Object>().ToList();
        }
        /*
        public void agregarAlumno(int matricula, string nombre, DateTime fechaNacimiento, int semestre, int facultad, int ciudad)
        {
            //se crea la conexión
            SqlConnection connection = new SqlConnection();
            //ocupa un servidor, una bd y un tipo de conexión
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //select a la tabla alumno
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_agregarAlumnos";
            command.Connection = connection;

            //PARA INSERT
            command.Parameters.AddWithValue("pMatricula", matricula);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFecha", fechaNacimiento);
            command.Parameters.AddWithValue("pSemestre", semestre);
            command.Parameters.AddWithValue("pFacultad", facultad);
            command.Parameters.AddWithValue("pCiudad", ciudad);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
        */
        public void agregarAlumno(Alumno alumno)
        {
            modelo.Alumno.Add(alumno);
            modelo.SaveChanges();
        }

        /*
        public DataTable cargarAlumno(int matricula)
        {
            //se crea la conexión
            SqlConnection connection = new SqlConnection();
            //ocupa un servidor, una bd y un tipo de conexión
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //select a la tabla alumno
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumnoPorMatricula";
            command.Connection = connection;

            //PARA INSERT
            command.Parameters.AddWithValue("pMatricula", matricula);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumno = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumno);

            connection.Close();

            return dtAlumno;

        }
        */

        public Alumno cargarAlumno(int matricula)
        {
            var alumno = (from mAlumno in modelo.Alumno
                           where mAlumno.matricula == matricula
                           select mAlumno).FirstOrDefault();

            return alumno;
        }

        /*
        public void modificarAlumno(int matricula, string nombre, DateTime fechaNacimiento, int semestre, int facultad, int ciudad)
        {
            //se crea la conexión
            SqlConnection connection = new SqlConnection();
            //ocupa un servidor, una bd y un tipo de conexión
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //select a la tabla alumno
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_modificarAlumno";
            command.Connection = connection;

            //PARA INSERT
            command.Parameters.AddWithValue("pMatricula", matricula);
            command.Parameters.AddWithValue("pNombre", nombre);
            command.Parameters.AddWithValue("pFecha", fechaNacimiento);
            command.Parameters.AddWithValue("pSemestre", semestre);
            command.Parameters.AddWithValue("pFacultad", facultad);
            command.Parameters.AddWithValue("pCiudad", ciudad);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        */

        public void modificarAlumno(Alumno pAlumno){
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == pAlumno.matricula
                          select mAlumno).FirstOrDefault();

            alumno.nombre = pAlumno.nombre;
            alumno.fechaNacimiento = pAlumno.fechaNacimiento;
            alumno.semestre = pAlumno.semestre;
            alumno.facultad = pAlumno.facultad;
            alumno.ciudad = pAlumno.ciudad;

            modelo.SaveChanges();
        }

        /*
        public void eliminarAlumno(int matricula)
        {
            //se crea la conexión
            SqlConnection connection = new SqlConnection();
            //ocupa un servidor, una bd y un tipo de conexión
            connection.ConnectionString = @"Server=DESKTOP-NP30A1I\SQLEXPRESS;Database=Escuela;Trusted_connection=true";

            //select a la tabla alumno
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_eliminarAlumnos";
            command.Connection = connection;

            //PARA INSERT
            command.Parameters.AddWithValue("pMatricula", matricula);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
        */

        public void eliminarAlumno(int matricula)
        {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == matricula
                          select mAlumno).FirstOrDefault();

            modelo.Alumno.Remove(alumno);
            modelo.SaveChanges();
        }
    }
}
