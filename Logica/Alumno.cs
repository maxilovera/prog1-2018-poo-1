using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Alumno : Persona
    {
        public int AñoCursado { get; set; }

        public override List<Inscripcion> ObtenerInscripciones(List<Inscripcion> inscripciones)
        {
            return inscripciones.Where(x => x.CodigoAlumno == Codigo).ToList();
        }
    }
}
