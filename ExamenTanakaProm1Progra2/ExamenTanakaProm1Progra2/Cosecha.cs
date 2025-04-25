using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Cosecha
    {
        private Queue<Cultivos> cola = new Queue<Cultivos>();
        public void Encolar(Cultivos c) => cola.Enqueue(c);
        public Cultivos Desencolar() => cola.Dequeue();
        public int Count => cola.Count;
    }
}
