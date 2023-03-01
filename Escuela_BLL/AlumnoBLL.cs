using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Escuela_BLL
{
    public class AlumnoBLL
    {
        public List<Object> cargarAlumnos() 
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumnos();
        }

        public void agregarAlumno(Alumno paramAlumno, List<MateriaAlumno> listMaterias)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            Alumno alum = new Alumno();
            MateriaAlumnoBLL matAlumBLL = new MateriaAlumnoBLL();
             

            alum = cargarAlumno(paramAlumno.matricula);

            if (alum!=null)//si el conteo de match es mayor a 0 significa que la matricula existe
            {
                throw new Exception("La matricula ya existe en la base de datos");
            }
            else
            {
                int edad = DateTime.Now.Year - paramAlumno.fechaNacimiento.Year;
                if (edad > 80)
                {
                    throw new Exception("El alumno es demasiado viejo. Ingresa otra edad");
                }
                else
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        alumno.agregarAlumno(paramAlumno);

                        foreach (MateriaAlumno materia in listMaterias)
                        {
                            matAlumBLL.agregarMateriaAlumno(materia);
                        }

                        ts.Complete();
                    }
                }
            }
        }

        public Alumno cargarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumno(matricula);
        }

        public void modificarAlumno(Alumno paramAlumno)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.modificarAlumno(paramAlumno);
        }

        public void eliminarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.eliminarAlumno(matricula);
        }
    }
}
