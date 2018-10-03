using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Universidad
    {
        public List<Alumno> Alumnos { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Alumno> Docentes { get; set; }
        public List<Inscripcion> Inscripciones { get; set; }

        public List<string> DatosPersonas()
        {
            List<string> resultado = new List<string>();
            foreach (var item in Alumnos)
            {
                resultado.Add($"Nombre y apellido: {item.NombreApellido} – Fecha de ingreso: {item.FechaIngreso}");
            }

            foreach (var item in Docentes)
            {
                resultado.Add($"Nombre y apellido: {item.NombreApellido} – Fecha de ingreso: {item.FechaIngreso}");
            }

            return resultado;
        }

        public ResultadoNota ObtenerNota(int codigoMateria, int codigoAlumno)
        {
            Inscripcion inscripcion = Inscripciones.Where(x => x.CodigoAlumno == codigoAlumno && x.CodigoMateria == codigoMateria).FirstOrDefault();
            ResultadoNota resultado = new ResultadoNota();

            if (inscripcion == null)
                resultado.Mensaje = "Examen no encontrado";
            else
            {
                if (DateTime.Now < inscripcion.FechaExamen)
                    resultado.Mensaje = "Examen Pediente";
                else
                    resultado.Nota = inscripcion.Nota;
            }

            return resultado;
        }

        public ResultadoActualizacion ActualizarNota(int codigoMateria, int codigoProfesor, int codigoAlumno, int nota)
        {
            Inscripcion inscripcion = Inscripciones.Where(x => x.CodigoAlumno == codigoAlumno && x.CodigoMateria == codigoMateria).FirstOrDefault();
            ResultadoActualizacion resultado = new ResultadoActualizacion() { Mensaje = "" };

            if (inscripcion == null)
                resultado.Mensaje = "Inscripcion no encontrada";
            else
            {
                if (DateTime.Now < inscripcion.FechaExamen)
                    resultado.Mensaje = "El examen no pasó aun";
                else
                {
                    if (inscripcion.CodigoProfesor != codigoProfesor)
                        resultado.Mensaje = "Nota actualizada por otro profesor";
                    else
                        inscripcion.Nota = nota;
                }
            }

            resultado.ResultadoValido = resultado.Mensaje == "";

            return resultado;
        }

        public List<Reporte> ReporteAprobaciones(int codigoAlumno)
        {
            List<Inscripcion> inscripcionesAlumno = Inscripciones.Where(x => DateTime.Now < x.FechaExamen 
            && x.CodigoAlumno == codigoAlumno && x.Nota >= 4).ToList();

            List<Reporte> reporte = new List<Reporte>();

            foreach (var item in inscripcionesAlumno)
            {
                Reporte nuevoItem = new Reporte();
                nuevoItem.FechaExamen = item.FechaExamen;
                nuevoItem.Materia = Materias.Where(x => x.Codigo == item.CodigoMateria).Select(x => x.Nombre).FirstOrDefault();
                nuevoItem.Nota = item.Nota;

                reporte.Add(nuevoItem);
            }

            return reporte;
        }
    }

}
