using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Modelo
{
    public class administrador
    {
        public string rut { get; set; }
        public string nombre { get;  set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        Conexion data = new Conexion();
        public DataSet listadoAdmin()
        {
            return data.listado("SELECT * FROM VM_CR_ADMINISTRADOR");
        }
        public DataSet listadoAdmin(string rut)
        {
            return data.listado("SELECT * FROM VM_CR_ADMINISTRADOR WHERE RUT= '" + rut + "'");
        }
        public int guardar()
        {
            return data.ejecutar("INSERT INTO VM_CR_ADMINISTRADOR(rut, nombre,telefono, direccion) values('" + this.rut + "','" + this.nombre + "', '" + this.telefono + "', '" + this.direccion + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM VM_CR_ADMINISTRADOR WHERE RUT = '" + this.rut + "'");
        }

        public int actualizar(string rut)
        {
            return data.ejecutar("UPDATE VM_CR_ADMINISTRADOR SET nombre='" + this.nombre + "', telefono='" + this.telefono + "', direccion='" + this.direccion + "' WHERE rut='" + rut + "'");
        }
    }
}
