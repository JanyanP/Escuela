using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;//nueva
using System.Data.SqlClient;//nueva
using Escuela_BLL;

namespace Escuela.Alumnos
{
    public partial class alumno_s : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//si es la primera vez que la pagina se carga
            {
                if (sesionIniciada())
                {
                    grd_alumnos.DataSource = cargarAlumnos();
                    grd_alumnos.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                
                
            }
        }
        protected void grd_alumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Alumnos/alumno_u.aspx?pMatricula="+e.CommandArgument);
            }
            else
            {
                Response.Redirect("~/Alumnos/alumno_d.aspx?pMatricula=" + e.CommandArgument);
            }
        }
        #endregion

        #region Metodos
        public List<object> cargarAlumnos()
        {
            AlumnoBLL alumnoBLL = new AlumnoBLL();
            //DataTable dtAlumnos = new DataTable();
            List<object> listAlumnos = new List<object>();

            listAlumnos = alumnoBLL.cargarAlumnos();

            return listAlumnos;

        }

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}