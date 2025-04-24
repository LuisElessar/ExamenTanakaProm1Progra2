using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Animales : Granja
    {
        public string Sonido { get; private set; }

        public Animales(string nombre, string sonido) : base(nombre)
        {
            Sonido = sonido;
        }

        public override void Info()
        {
            Console.WriteLine($"Animal: {Nombre}, Sonido: {Sonido}");
        }

        public void HacerSonido()
        {
            Console.WriteLine($"{Nombre} hace: {Sonido}");
        }
    }
}
