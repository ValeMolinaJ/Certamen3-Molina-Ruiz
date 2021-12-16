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
        private string rut;
        private string nombre;
        private string telefono;
        private string direccion;

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public administrador()
        {

        }
        public administrador(string rut, string nombre, string telefono, string direccion)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
        }

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
