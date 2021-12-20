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
    public class AdministradorController : ApiController
    {
        //Método para traer datos.
        [HttpGet]
        [Route("api/lista/admin")]
        public respuesta listar(string rut = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<administradores> listado = new List<administradores>();
                administrador adminData = new administrador();
                DataSet data = rut == "" ? adminData.listadoAdmin() : adminData.listadoAdmin(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    administradores item = new administradores();
                    item.rut = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.direccion = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    listado.Add(item);
                }
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else
                    resp.data = "No se encontro el administrador";
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
        [Route("api/setAdmin")]
        public respuesta guardar(administradores administrador)
        {
            respuesta resp = new respuesta();
            try
            {
                administrador admin = new administrador(administrador.rut, administrador.nombre,administrador.telefono, administrador.direccion);
                int estado = admin.guardar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Administrador ingresado";
                    resp.data = administrador;
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
        //Método para eliminar datos.
        [HttpDelete]
        [Route("api/deleteAdmin")]
        public respuesta eliminar(string rut)
        {
            respuesta resp = new respuesta();
            try
            {
                administrador admin = new administrador();
                admin.Rut = rut;
                int estado = admin.eliminar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Administrador eliminado";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la eliminación";
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
        //Método para actualizar datos.
        [HttpPut]
        [Route("api/updateAdmin")]
        public respuesta actualizar(administradores administrador)
        {
            respuesta resp = new respuesta();
            try
            {
                administrador admin = new administrador(administrador.rut, administrador.nombre, administrador.telefono, administrador.direccion);
                int estado = admin.actualizar(administrador.rut);
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Administrador Modificado";
                    resp.data = administrador;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la modificación";
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