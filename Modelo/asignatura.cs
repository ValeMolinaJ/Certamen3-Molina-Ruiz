using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Modelo
{
    public class asignatura
    {
        private string idAsig { get; set; }
        private string nombreAsig { get; set; }
        public asignatura()
        {

        }
        public asignatura(string idAsig, string nombreAsig)
        {
            this.idAsig = idAsig;
            this.nombreAsig = nombreAsig;
        }

        Conexion data = new Conexion();
        public DataSet listadoAsig()
        {
            return data.listado("SELECT * FROM VM_CR_ASIGNATURA");
        }
        public DataSet listadoAsig(string idAsig)
        {
            return data.listado("SELECT * FROM VM_CR_ASIGNATURA WHERE idAsig= '" + idAsig + "'");
        }
        public int guardar()
        {
            return data.ejecutar("INSERT INTO VM_CR_ASIGNATURA(idAsig, nombreAsig) values('" + this.idAsig + "','" + this.nombreAsig +"')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM VM_CR_ASIGNATURA WHERE  idAsig= '" + this.idAsig + "'");
        }

        public int actualizar(string idAsig)
        {
            return data.ejecutar("UPDATE VM_CR_ASIGNATURA SET nombreAsig='" + this.nombreAsig +"' WHERE idAsig='" + idAsig + "'");
        }
    }
}
