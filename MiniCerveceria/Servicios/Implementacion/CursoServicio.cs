﻿using MiniCerveceria.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace MiniCerveceria.Servicios.Implementacion
{
    public class CursoServicio : ICursoAplicacionServicios
	{
        static Controladores.Conexion db = new Controladores.Conexion();
        public CursoServicio(string conn)
        {
            db = new Controladores.Conexion(conn);
        }
        public void CrearCurso(Curso obj)
        {
            string query = @"DECLARE " +
                                 "v_id_curso NUMBER(10) := " + obj.id_curso + ";" +
                            " BEGIN " +
                                " IF (v_id_curso > 0) THEN " +
                                    " UPDATE curso SET nombre_curso = '" + obj.nombre_curso + "'," +
                                                     "descripcion = '" + obj.descripcion + "'," +
                                                     "precio = " + obj.precio + "," +
                                                     "estado = " + obj.estado + "," +
                                                     "url_img = '" + obj.URL_img + "'," +
                                                     "fecha_modificacion = CURRENT_DATE " +
                                     " WHERE id_curso = v_id_curso; " +
                                 " ELSE " +
                                     " INSERT INTO curso (id_curso," +
                                                        "nombre_curso," +
                                                        "descripcion," +
                                                        "precio," +
                                                        "estado," +
                                                        "url_img," +
                                                        "fecha_creacion," +
                                                        "fecha_modificacion) " +
                                     " VALUES(" + ObtenerIDCurso() + ", '" + obj.nombre_curso.Replace("'", "''") + "', '" + obj.descripcion.Replace("'", "''") + "', " + obj.precio + ", " + obj.estado + ", '" + obj.URL_img + "', CURRENT_DATE, CURRENT_DATE); " +
                                 " END IF;" +
                            " END;";
            db.Execute(query);
        }
        public IList<Curso> ObtenerCursos(bool estado)
        {
            string query = "SELECT id_curso, " +
                                  "nombre_curso, " +
                                  "descripcion, " +
                                  "precio, " +
                                  "estado, " +
                                  "fecha_creacion, " +
                                  "fecha_modificacion, " +
								  "url_img " +
						   "FROM curso WHERE estado = " + (estado?1:0);
            DataTable dt = db.Execute(query);

            IList<Curso> lista = new List<Curso>();
            if (dt.Rows.Count > 0)
            {
                lista = (from DataRow rw in dt.Rows
                         select new Curso()
                         {
                             id_curso = Convert.ToInt32(rw["id_curso"]),
                             nombre_curso = Convert.ToString(rw["nombre_curso"]),
                             descripcion = Convert.ToString(rw["descripcion"]),
                             precio = Convert.ToInt32(rw["precio"]),
                             estado = Convert.ToInt32(rw["estado"]),
                             fecha_creacion = Convert.ToDateTime(rw["fecha_creacion"]),
                             fecha_modificacion = Convert.ToDateTime(rw["fecha_modificacion"]),
							 URL_img = rw["url_img"].ToString(),
						 }
                        ).ToList();
                return lista;
            }
            else
            {
                return lista;
            }
        }

		public IList<Curso> ObtenerTodoCursos()
		{
			string query = "SELECT id_curso, " +
								  "nombre_curso, " +
								  "descripcion, " +
								  "precio, " +
								  "estado, " +
								  "fecha_creacion, " +
								  "fecha_modificacion, " +
								  "url_img " +
						   "FROM curso ";
			DataTable dt = db.Execute(query);

			IList<Curso> lista = new List<Curso>();
			if (dt.Rows.Count > 0)
			{
				lista = (from DataRow rw in dt.Rows
						 select new Curso()
						 {
							 id_curso = Convert.ToInt32(rw["id_curso"]),
							 nombre_curso = Convert.ToString(rw["nombre_curso"]),
							 descripcion = Convert.ToString(rw["descripcion"]),
							 precio = Convert.ToInt32(rw["precio"]),
							 estado = Convert.ToInt32(rw["estado"]),
							 fecha_creacion = Convert.ToDateTime(rw["fecha_creacion"]),
							 fecha_modificacion = Convert.ToDateTime(rw["fecha_modificacion"]),
							 URL_img = rw["url_img"].ToString(),
						 }
						).ToList();
				return lista;
			}
			else
			{
				return lista;
			}
		}
		public void DeshabilitarCurso(int id_curso)
        {
            string query = @"UPDATE curso SET estado = 0 " +
                            "WHERE id_curso = " + id_curso;
            db.Execute(query);
        }
        public int ObtenerIDCurso()
        {
            try
            {
                string query = @"SELECT MAX(id_curso) AS idCurso FROM curso";
                DataTable dt = db.Execute(query);
                int id_curso = Convert.ToInt32(dt.Rows[0]["idCurso"]);
                return id_curso + 1;

            }
            catch (Exception)
            {
                return 1;
                throw;
            }
        }
        public void HabilitarCurso(int id_curso)
		{
			string query = @"UPDATE curso SET estado = 1 " +
							"WHERE id_curso = " + id_curso;
			db.Execute(query);
		}
		public Curso ObtenerCurso(int id_curso)
        {
            string query = @"SELECT id_curso, " +
                                   "nombre_curso, " +
                                   "descripcion, " +
                                   "precio, " +
                                   "estado, " +
                                   "url_img, " +
                                   "fecha_creacion, " +
                                   "fecha_modificacion, " +
								   "url_img " +
							"FROM curso " +
                            "WHERE id_curso = " + id_curso;
            DataTable dt = db.Execute(query);

            Curso obj = new Curso();
            if (dt.Rows.Count > 0)
            {
                obj = (from DataRow rw in dt.Rows
                       select new Curso()
                       {
                           id_curso = Convert.ToInt32(rw["id_curso"]),
                           nombre_curso = Convert.ToString(rw["nombre_curso"]),
                           descripcion = Convert.ToString(rw["descripcion"]),
                           precio = Convert.ToInt32(rw["precio"]),
                           estado = Convert.ToInt32(rw["estado"]),
                           fecha_creacion = Convert.ToDateTime(rw["fecha_creacion"]),
                           fecha_modificacion = Convert.ToDateTime(rw["fecha_modificacion"]),
						   URL_img = rw["url_img"].ToString(),
					   }).FirstOrDefault();
            }

            return obj;
        }
    }
}