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
            Program juego = new Program();
            juego.Iniciar();
        }

        private Jugador jugador = new Jugador();
        private Tienda tienda = new Tienda();
        private Granjeroslog log = new Granjeroslog();
        private List<Cultivos> cultivos = new List<Cultivos>();
        private List<Animales> animales = new List<Animales>();
        private Cosecha colaCosecha = new Cosecha();
        private int diaActual = 1;

        public void Iniciar()
        {
            bool jugando = true;
            while (jugando)
            {
                Console.WriteLine($"\n--- Día {diaActual} ---");
                jugador.MostrarMonedas();
                Console.WriteLine("1. Ir a tienda");
                Console.WriteLine("2. Plantar cultivo");
                Console.WriteLine("3. Cosechar cultivos listos");
                Console.WriteLine("4. Comprar animal");
                Console.WriteLine("5. Alimentar animales");
                Console.WriteLine("6. Ver estado de granja");
                Console.WriteLine("7. Pasar al siguiente día");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                var op = Console.ReadLine();
                switch (op)
                {
                    case "1": AccionTienda(); break;
                    case "2": AccionPlantar(); break;
                    case "3": AccionCosechar(); break;
                    case "4": AccionComprarAnimal(); break;
                    case "5": AccionAlimentar(); break;
                    case "6": AccionVer(); break;
                    case "7": PasarDia(); break;
                    case "0": jugando = false; continue;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }
        }
        private void AccionTienda()
        {
            tienda.MostrarProductos();
            Console.Write("Producto a comprar: ");
            var prod = Console.ReadLine();
            if (tienda.TryComprar(prod, jugador.Monedas, out int precio))
            {
                jugador.CambiarMonedas(-precio);
                log.Registrar($"Comprado {prod}");
                if (prod == "Maíz" || prod == "Trigo") cultivos.Add(new Cultivos(prod, 3));
                else animales.Add(new Animales(prod));
                Console.WriteLine($"Compraste {prod}.");
            }
            else Console.WriteLine("No puedes comprar eso.");
        }
        private void AccionPlantar()
        {
            Console.Write("Tipo de cultivo (Maíz/Trigo): ");
            var tipo = Console.ReadLine();
            cultivos.Add(new Cultivos(tipo, 3));
            log.Registrar($"Plantado {tipo}");
        }
        private void AccionCosechar()
        {
            List<Cultivos> cosechados = new List<Cultivos>();
            foreach (var c in cultivos)
                if (c.ListoParaCosecha)
                    colaCosecha.Encolar(c);

            while (colaCosecha.Count > 0)
            {
                var c = colaCosecha.Desencolar();
                Console.WriteLine($"Cosechaste {c.Nombre}");
                jugador.CambiarMonedas(5);
                log.Registrar($"Cosechado {c.Nombre}");
                cosechados.Add(c);
            }
            
            foreach (var c in cosechados)
                cultivos.Remove(c);
        }
        private void AccionComprarAnimal()
        {
            Console.Write("Tipo de animal (Gallina/Vaca): ");
            var tipo = Console.ReadLine();
            animales.Add(new Animales(tipo));
            log.Registrar($"Comprado animal {tipo}");
        }
        private void AccionAlimentar()
        {
            foreach (var a in animales)
            {
                a.Interactuar();
                log.Registrar($"Alimentado {a.Nombre}");
            }
        }
        private void AccionVer()
        {
            Console.WriteLine("-- Cultivos --");
            foreach (var c in cultivos) c.Info();
            Console.WriteLine("-- Animales --");
            foreach (var a in animales) a.Info();
            log.Mostrar();
        }
        private void PasarDia()
        {
            diaActual++;
            if (diaActual % 30 == 0)
            {
                Console.WriteLine("Día de pago de alquiler: 50 monedas");
                if (jugador.Monedas < 50)
                {
                    Console.WriteLine("No tienes para pagar el alquiler. Fin del juego.");
                    Environment.Exit(0);
                }
                else jugador.CambiarMonedas(-50);
            }
            foreach (var c in cultivos) c.Interactuar();
            foreach (var a in animales) a.PasarDia();
        }

    }
}
