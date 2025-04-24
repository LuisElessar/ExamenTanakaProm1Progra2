using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class GranjaManager
    {
        private List<Cultivos> cultivos = new List<Cultivos>();
        private List<Animales> animales = new List<Animales>();
        private Stack<string> logAcciones = new Stack<string>();
        private Queue<Cultivos> colaCosecha = new Queue<Cultivos>();
        private Dictionary<string, int> precios = new Dictionary<string, int>()
    {
             { "Maíz", 5 },
             { "Trigo", 3 },
             { "Gallina", 20 }
    };

        public void Plantar(string tipo)
        {
            try
            {
                if (precios.ContainsKey(tipo))
                {
                    Cultivos nuevo = new Cultivos(tipo, 3);
                    cultivos.Add(nuevo);
                    logAcciones.Push($"Plantado {tipo}");
                    Console.WriteLine($"Plantaste {tipo}.");
                }
                else
                {
                    Console.WriteLine("Cultivo no disponible.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al plantar: {ex.Message}");
            }
        }

        public void Cosechar()
        {
            foreach (var c in cultivos)
            {
                if (c.ListoParaCosecha)
                    colaCosecha.Enqueue(c);
            }

            while (colaCosecha.Count > 0)
            {
                var cosechado = colaCosecha.Dequeue();
                Console.WriteLine($"Has cosechado: {cosechado.Nombre}");
                logAcciones.Push($"Cosechado {cosechado.Nombre}");
            }
        }

        public void ComprarAnimal(string tipo)
        {
            try
            {
                if (precios.ContainsKey(tipo))
                {
                    Animales nuevo = new Animales(tipo);
                    animales.Add(nuevo);
                    logAcciones.Push($"Comprado {tipo}");
                    Console.WriteLine($"Compraste un(a) {tipo}.");
                }
                else
                {
                    Console.WriteLine("Animal no disponible.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al comprar: {ex.Message}");
            }
        }

        public void VerLog()
        {
            Console.WriteLine("Acciones recientes:");
            foreach (var log in logAcciones)
            {
                Console.WriteLine($"- {log}");
            }
        }
    }
}
