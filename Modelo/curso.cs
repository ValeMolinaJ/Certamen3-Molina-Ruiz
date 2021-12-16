using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class curso
    {
        private int idCurso { get; set; }
        private string nombreCurso { get; set; }
        private coordinador coordinador { get; set; }
        private List<asignatura> asignaturas { get; set; }
        private sede nombreSede { get; set; }
    }
}
