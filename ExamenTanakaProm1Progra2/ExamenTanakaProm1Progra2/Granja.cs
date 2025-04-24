using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal abstract class Granja
    {
        public string Nombre { get; protected set; }

        public Granja(string nombre)
        {
            Nombre = nombre;
        }

        public abstract void Info();

    }
}
