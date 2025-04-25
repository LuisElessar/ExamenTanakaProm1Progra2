using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Jugador
    {
        public int Monedas { get; private set; } = 100;
        public void CambiarMonedas(int delta) => Monedas += delta;
        public void MostrarMonedas() => Console.WriteLine($"Monedas: {Monedas}");
    }
}
