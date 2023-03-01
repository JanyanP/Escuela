using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Escuela_BLL;
using Escuela_DAL;

namespace Escuela.Alumnos
{
    public partial class alumno_d : TemaEscuela,IAcceso
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    cargarFacultades();
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarAlumno(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno eliminado existosamente.')", true);
        }

        #region Metodos

        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = alumno.matricula.ToString();
            lblNombre.Text = alumno.nombre;
            lblFechaNacimiento.Text = alumno.fechaNacimiento.ToString().Substring(0, 10);
            lblSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue = alumno.facultad.ToString();

        }

        public void cargarFacultades()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            //DataTable dtFacultades = new DataTable();
            List<Facultad> listFacultades = new List<Facultad>();

            listFacultades = facuBLL.cargarFacultades();

            ddlFacultad.DataSource = listFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("---- Seleccione Facultad ----", "0"));
        }

        public void eliminarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            int matricula = int.Parse(lblMatricula.Text);

            alumBLL.eliminarAlumno(matricula);
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