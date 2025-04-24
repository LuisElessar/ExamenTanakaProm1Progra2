using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                GranjaManager granja = new GranjaManager();
                bool continuar = true;

                while (continuar)
                {
                    Console.WriteLine("\n--- Menú Granja ---");
                    Console.WriteLine("1. Plantar Maíz");
                    Console.WriteLine("2. Cosechar");
                    Console.WriteLine("3. Ver acciones");
                    Console.WriteLine("0. Salir");
                    Console.Write("Opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            granja.Plantar("Maíz");
                            break;
                        case "2":
                            granja.Cosechar();
                            break;
                        case "3":
                            granja.VerLog();
                            break;
                        case "0":
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            }
        }
    }
}
