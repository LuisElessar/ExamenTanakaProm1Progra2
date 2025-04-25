using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Animales : Granja
    {
        private int diasSinComer;
        private int vecesAlimentado;
        public bool EstaVivo => diasSinComer < 3;
        public bool ListoParaVenta => vecesAlimentado >= 3;
        public Animales(string nombre) : base(nombre)
        {
            diasSinComer = 0;
            vecesAlimentado = 0;
        }
        public void Interactuar() => Alimentar();
        private void Alimentar()
        {
            diasSinComer = 0;
            vecesAlimentado++;
            Console.WriteLine($"Has alimentado {Nombre}. Veces alimentado: {vecesAlimentado}");
        }
        public void PasarDia() => diasSinComer++;
        public override void Info() => Console.WriteLine($"Animal: {Nombre}, Días sin comer: {diasSinComer}, Veces alimentado: {vecesAlimentado}");
    }
}
