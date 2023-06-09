﻿using MiniCerveceria.Modelos;
using MiniCerveceria.Servicios.Implementacion;
using MiniCerveceria.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniCerveceria.Mantenedores.Productos
{
	public partial class StockProducto : System.Web.UI.Page
	{
		static string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		static IProductoAplicacionServicios productoApp = new ProductoServicio(conn);
		static IUsuarioAplicacionServicios usuarioApp = new UsuarioServicio(conn);

		public string PermiosEditar = "false";

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

					PermiosEditar = permisosUsusario.editar ? "true" : "false";
				}
				else
				{
					PermiosEditar = "true";
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static IList<Producto> ListarStockProductosDefualt()
		{
			try
			{
				IList<Producto> ListProductos = new List<Producto>();

				ListProductos = productoApp.ListarProductos(true);

				return ListProductos;
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static bool AumentarStock(string id_producto, string cantidad)
		{
			try
			{
				productoApp.AumentarStock(Convert.ToInt32(id_producto), Convert.ToInt32(cantidad));

				return true;
			}
			catch (Exception)
			{
				return false;

				throw;
			}
		}

		[WebMethod(EnableSession = true)]
		public static bool RebajarStock(string id_producto, string cantidad)
		{
			try
			{
				productoApp.RebajarStock(Convert.ToInt32(id_producto), Convert.ToInt32(cantidad));

				return true;
			}
			catch (Exception)
			{
				return false;

				throw;
			}
		}
	}
}