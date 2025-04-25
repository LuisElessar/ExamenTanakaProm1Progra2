using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Granjeroslog
    {
        private Stack<string> logAcciones = new Stack<string>();
        public void Registrar(string accion)
        {
            logAcciones.Push(accion);
        }
        public void Mostrar()
        {
            Console.WriteLine("Log de acciones:");
            foreach (var a in logAcciones) Console.WriteLine($"- {a}");
        }
    }
}
