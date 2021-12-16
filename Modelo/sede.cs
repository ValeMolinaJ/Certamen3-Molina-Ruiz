using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class sede
    {
        private int idSede { get; set; }
        private string nombreSede { get; set; }
        private string direccion { get; set; }
        private string telefono { get; set; }
        private administrador administrador { get; set; }
    }
}
