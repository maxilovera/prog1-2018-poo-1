using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public abstract class Persona
    {
        public int Codigo { get; set; }
        public string NombreApellido { get; set; }
        public int DNI { get; set; }
        public string LocalidadOrigen { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }

        public string ObtenerDescripcionPersona()
        {
            return $"Nombre y apellido: {NombreApellido} – Fecha de ingreso: {FechaIngreso}";
        }

        public abstract List<Inscripcion> ObtenerInscripciones(List<Inscripcion> inscripciones);
    }
}
