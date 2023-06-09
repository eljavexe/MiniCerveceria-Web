﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniCerveceria.Modelos
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public bool estado { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public int categoria { get; set; }
        public string URL_img { get; set; }
        public int sub_categoria { get; set; }
        public int stock { get; set; }
        public bool novedad { get; set; }
	}
}