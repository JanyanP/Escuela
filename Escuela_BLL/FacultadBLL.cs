using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Data.SqlClient;
using System.Data;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public List<Facultad> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }
    }
}
