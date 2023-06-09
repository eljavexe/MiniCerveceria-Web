﻿using MiniCerveceria.Modelos;
using MiniCerveceria.Servicios;
using MiniCerveceria.Servicios.Implementacion;
using MiniCerveceria.Servicios.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniCerveceria.Mantenedores.Cursos
{
	public partial class CursosInscritos : System.Web.UI.Page
	{
		static string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		static ICursosInscritosAplicacionServicios cursoInscirtoApp = new CursosInscritosServicio(conn);
		static IUsuarioAplicacionServicios usuarioApp = new UsuarioServicio(conn);
		static ICursoAplicacionServicios cursoApp = new CursoServicio(conn);

		public string PermisoEditar = "false";
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				MasterAdmin MasterAdmin = (MasterAdmin)(Session["MasterAdminSesion"]);
				Usuario oUsuario = (Usuario)(Session["UsuarioSesion"]);

				if (MasterAdmin == null)
				{
					if (oUsuario == null)
					{
						Response.Redirect("~/Default.aspx", false);
						return;
					}

					if (oUsuario.email == null)
					{
						Response.Redirect("~/Default.aspx", false);
						return;
					}

					if (oUsuario.id_permiso == 0)
					{
						Response.Redirect("~/Default.aspx", false);
						return;
					}
					PermisosUsusario permisosUsusario = new PermisosUsusario();
					permisosUsusario = usuarioApp.ObtenerPermiso(oUsuario.id_permiso);

					PermisoEditar = permisosUsusario.editar ? "true" : "false";
				}
				else
				{
					PermisoEditar = "true";
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static IList<InscripcionCurso> CargarCursosInscritos(int id_curso, string cursado)
		{
			try
			{
				IList<InscripcionCurso> inscripciones = new List<InscripcionCurso>();

				inscripciones = cursoInscirtoApp.ObtenerCursosInscritos(id_curso, cursado);

				return inscripciones;
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static IList<Curso> CargarCursos()
		{
			try
			{
				IList<Curso> ListCursos = new List<Curso>();

				ListCursos = cursoApp.ObtenerTodoCursos();

				return ListCursos;
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static void CambiarEstado(string id_inscripcion, string estado)
		{
			try
			{
				cursoInscirtoApp.CambioEstado(Convert.ToInt32(id_inscripcion), Convert.ToBoolean(estado));
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}