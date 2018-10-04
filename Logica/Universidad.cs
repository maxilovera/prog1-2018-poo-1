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
            foreach (var alumno in Alumnos)
            {
                resultado.Add($"Nombre y apellido: {alumno.NombreApellido} – Fecha de ingreso: {alumno.FechaIngreso}");
                resultado.Add(alumno.ObtenerDescripcionPersona());
            }

            foreach (var docente in Docentes)
            {
                resultado.Add($"Nombre y apellido: {docente.NombreApellido} – Fecha de ingreso: {docente.FechaIngreso}");
                resultado.Add(docente.ObtenerDescripcionPersona());
            }

            return resultado;
        }

        public ResultadoNota ObtenerNota(int codigoMateria, int codigoAlumno)
        {
            Inscripcion inscripcion = Inscripciones.Where(x => x.CodigoAlumno == codigoAlumno && x.CodigoMateria == codigoMateria).FirstOrDefault(); //SingleOrDefault()

            ResultadoNota resultado = new ResultadoNota();

            if (inscripcion == null)
                resultado.Mensaje = "Examen no encontrado";
            else
            {
                if (DateTime.Now < inscripcion.FechaExamen)
                    resultado.Mensaje = "Examen Pendiente";
                else
                    resultado.Nota = inscripcion.Nota;
            }

            return resultado;
        }

        public ResultadoActualizacion ActualizarNota(int codigoMateria, int codigoProfesor, int codigoAlumno, int nota)
        {
            Inscripcion inscripcion = Inscripciones.Where(x => x.CodigoAlumno == codigoAlumno 
                                                            && x.CodigoMateria == codigoMateria).FirstOrDefault();

            ResultadoActualizacion resultado = new ResultadoActualizacion() { Mensaje = "" };

            if (inscripcion == null)
                resultado.Mensaje = "Inscripcion no encontrada";
            else
            {
                if (DateTime.Now < inscripcion.FechaExamen)
                    resultado.Mensaje = "El examen no pasó aun";
                else
                {
                    if (inscripcion.CodigoProfesor != 0 && inscripcion.CodigoProfesor != codigoProfesor)
                        resultado.Mensaje = "Nota actualizada por otro profesor";
                    else
                    {
                        inscripcion.Nota = nota;
                        inscripcion.CodigoProfesor = codigoProfesor;
                    }
                }
            }

            resultado.ResultadoValido = resultado.Mensaje == "";
            //if (resultado.Mensaje == "")
            //    resultado.ResultadoValido = true;
            //else
            //    resultado.ResultadoValido = false;
            return resultado;
        }

        public List<Reporte> ReporteAprobaciones(int codigoAlumno)
        {
            List<Inscripcion> inscripcionesAlumno = Inscripciones.Where(x => DateTime.Now < x.FechaExamen 
            && x.CodigoAlumno == codigoAlumno && x.Nota >= 4).ToList();

            List<Reporte> reporte = new List<Reporte>();

            /*
             * Materias = [{Codigo=1, Nombre="Matematica"}, {Codigo=2, Nombre="Literatura"}]
             * materias.Select(x=>x.Nombre) 
             * ["Matematica", "Literatura"].FirstOrDefault()
             * "Matematica"
             */ 


            foreach (var item in inscripcionesAlumno)
            {
                string nombreMateria = "";
                foreach (var materia in Materias)
                {
                    if (materia.Codigo == item.CodigoMateria)
                        nombreMateria = materia.Nombre;
                }

                Materia materiaInscripcion = Materias.Where(x => x.Codigo == item.CodigoMateria).FirstOrDefault();

                Reporte nuevoItem = new Reporte();
                nuevoItem.FechaExamen = item.FechaExamen;
                nuevoItem.Materia = Materias.Where(x => x.Codigo == item.CodigoMateria).Select(x => x.Nombre).FirstOrDefault();
                //nuevoItem.Materia = nombreMateria;
                //nuevoItem.Materia = materiaInscripcion.Nombre;
                nuevoItem.Nota = item.Nota;

                reporte.Add(nuevoItem);
            }

            return reporte;
        }
    }

}
