using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplicationOtec.Models;

namespace WebApplicationOtec.Controllers
{
    public class AsignaturaController : ApiController
    {
        //Método para traer datos.
        [HttpGet]
        [Route("api/listado/asignaturas")]
        public respuesta listar(string idAsig = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<asignaturas> listado = new List<asignaturas>();
                asignatura asigData = new asignatura();
                DataSet data = idAsig == "" ? asigData.listadoAsig() : asigData.listadoAsig(idAsig);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    asignaturas item = new asignaturas();
                    item.idAsig = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombreAsig = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    listado.Add(item);
                }
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else

                    resp.data = "No se encontro la asignatura";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;

            }
        }
        //Método para insertar datos.
        [HttpPost]
        [Route("api/setAsignatura")]
        public respuesta guardar(asignaturas asignatura)
        {
            respuesta resp = new respuesta();
            try
            {
                asignatura asig = new asignatura(asignatura.idAsig, asignatura.nombreAsig);
                int estado = asig.guardar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura ingresada";
                    resp.data = asignatura;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó el ingreso";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
    }
}