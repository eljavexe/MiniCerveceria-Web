﻿using MiniCerveceria.Servicios.Implementacion;
using MiniCerveceria.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using MiniCerveceria.Modelos;
using System.IO;


namespace MiniCerveceria.Ventanas.Cuenta
{
	public partial class Cuenta : System.Web.UI.Page
	{
		static string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		static IUsuarioAplicacionServicios UsuarioApp = new UsuarioServicio(conn);

		public int id_user = 0;
		public string fechaNacimiento = "";
		public string OptionSelectedSide = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			string uid = Request.QueryString["uid"] != null ? Request.QueryString["uid"] : "";

			if (uid != "")
			{
				OptionSelectedSide = uid;
			}

			Usuario oUsuario = (Usuario)(Session["UsuarioSesion"]);

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

			fechaNacimiento = oUsuario.fecha_nacimiento.ToString("yyyy-MM-dd");
			id_user = oUsuario.id_usuario;
		}

		[WebMethod(EnableSession = true)]
		public static Usuario ObteneSatosUSuario()
		{
			try
			{
				Usuario SesionUser = (Usuario)(HttpContext.Current.Session["UsuarioSesion"]);

				return SesionUser;
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static void ActualizarDatos(string nombre,string apellido, string fechanacimiento, string direccion, string email, string telefono)
		{
			try
			{
				Usuario SesionUser = (Usuario)(HttpContext.Current.Session["UsuarioSesion"]);

				Usuario oUsuario = SesionUser;

				oUsuario.nombre = nombre;
				oUsuario.apellido = apellido;
				oUsuario.fecha_nacimiento = Convert.ToDateTime(fechanacimiento);
				oUsuario.direccion = direccion;
				oUsuario.email = email;
				oUsuario.telefono = Convert.ToInt32(telefono);

				UsuarioApp.ActualizarUsuario(oUsuario);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}


}