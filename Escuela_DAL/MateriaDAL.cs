using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class MateriaDAL
    {
        EscuelaEntities modelo;

        public MateriaDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Materia> cargarMateria()
        {
            var materias = from mMaterias in modelo.Materia
                          select mMaterias;
            return materias.ToList();
        }
    }
}
