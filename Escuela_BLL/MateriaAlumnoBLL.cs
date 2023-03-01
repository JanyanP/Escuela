using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class MateriaAlumnoBLL
    {
        public void agregarMateriaAlumno(MateriaAlumno materia)
        {
            MateriaAlumnoDAL matAlumno = new MateriaAlumnoDAL();
            matAlumno.agregarMateriaAlumno(materia);
        }
    }
}
