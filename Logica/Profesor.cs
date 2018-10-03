using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public enum TipoProfesor
    {
        Jtp, Adjunto, Ayudante
    }
    public class Profesor : Persona
    {
        public TipoProfesor Tipo { get; set; }

        public override List<Inscripcion> ObtenerInscripciones(List<Inscripcion> inscripciones)
        {
            return inscripciones.Where(x => x.CodigoProfesor == Codigo).ToList();
        }
    }
}
