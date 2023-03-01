using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        EscuelaEntities modelo;
        public FacultadDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Facultad> cargarFacultades()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select mFacultades;

            return facultades.ToList();
        }
    }
}
