using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Materia
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public Materia()
        {

        }

        public Materia(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}
