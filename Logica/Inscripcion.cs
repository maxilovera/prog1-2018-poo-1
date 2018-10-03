using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Inscripcion
    {
        public int CodigoMateria { get; set; }
        public int CodigoProfesor { get; set; }
        public int CodigoAlumno { get; set; }
        public bool InscripcionLibre { get; set; }
        public DateTime FechaExamen { get; set; }
        public int Nota { get; set; }

    }
}
