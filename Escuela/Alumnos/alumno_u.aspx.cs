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
    public partial class alumno_u : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    cargarFacultades();
                    cargarEstados();
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarAlumno(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modificarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno modificado existosamente.')", true);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedIndex != 0)
            {
                ddlCiudad.Items.Clear();
                cargarCiudades();
            }
            else
            {
                ddlCiudad.Items.Clear();
            }
        }

        #endregion

        #region Metodos
        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = alumno.matricula.ToString();
            txtNombre.Text = alumno.nombre;
            txtFechaNacimiento.Text = alumno.fechaNacimiento.ToString().Substring(0,10);
            txtSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue =alumno.facultad.ToString();

            cargarEstados();
            ddlEstado.SelectedValue = alumno.Ciudad1.estado.ToString();

            cargarCiudades();
            ddlCiudad.SelectedValue = alumno.ciudad.ToString();
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

        public void modificarAlumno()
        {
            AlumnoBLL alumnoBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno.matricula = int.Parse(lblMatricula.Text);
            alumno.nombre = txtNombre.Text;
            alumno.fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            alumno.semestre = int.Parse(txtSemestre.Text);
            alumno.facultad = int.Parse(ddlFacultad.SelectedValue);
            alumno.ciudad = int.Parse(ddlCiudad.SelectedValue);

            alumnoBLL.modificarAlumno(alumno);


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

        public void cargarEstados()
        {
            EstadoBLL estado = new EstadoBLL();
            DataTable dtEstados = new DataTable();

            dtEstados = estado.cargarEstados();

            ddlEstado.DataSource = dtEstados;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem("---- Seleccione Estado ----", "0"));
        }

        public void cargarCiudades()
        {
            CiudadBLL ciudad = new CiudadBLL();
            DataTable dtCiudades = new DataTable();

            dtCiudades = ciudad.cargarCiudadesPorEstado(int.Parse(ddlEstado.SelectedValue));

            ddlCiudad.DataSource = dtCiudades;
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem("---- Seleccione Ciudad ----", "0"));
        }

        #endregion
    }
}