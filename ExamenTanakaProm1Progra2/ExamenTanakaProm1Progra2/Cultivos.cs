using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Cultivos : Granja, IInterfaz
    {
        public int DiasParaCosechar { get; private set; }
        public bool ListoParaCosecha => DiasParaCosechar <= 0;

        public Cultivos(string nombre, int dias) : base(nombre)
        {
            DiasParaCosechar = dias;
        }

        public override void Info()
        {
            Console.WriteLine($"Cultivo: {Nombre}, Días para cosechar: {DiasParaCosechar}");
        }

        public void Interactuar()
        {
            if (DiasParaCosechar > 0)
            {
                DiasParaCosechar--;
                Console.WriteLine($"Has regado {Nombre}. Días restantes: {DiasParaCosechar}");
            }
            else
            {
                Console.WriteLine($"{Nombre} ya está listo para cosechar.");
            }
        }
    }
}
