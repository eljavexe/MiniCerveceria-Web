﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniCerveceria.Mantenedores.Usuarios
{
    public partial class VerUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.QueryString["uid"] != null ? Request.QueryString["uid"] : "";

            lblNombreItem.Text = uid == "" ? "Novedades xxxxxx" : uid;
        }
    }
}