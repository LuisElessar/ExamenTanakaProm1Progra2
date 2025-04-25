using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Tienda
    {
        private Dictionary<string, int> precios = new Dictionary<string, int>
    {
        { "Maíz", 5 }, { "Trigo", 3 }, { "Gallina", 20 }, { "Vaca", 50 }
    };
        public void MostrarProductos()
        {
            Console.WriteLine("Productos en tienda:");
            foreach (var kv in precios) Console.WriteLine($"{kv.Key}: {kv.Value} monedas");
        }
        public bool TryComprar(string producto, int monedas, out int precio)
        {
            precio = 0;
            try
            {
                if (!precios.ContainsKey(producto)) return false;
                precio = precios[producto];
                if (monedas < precio) return false;
                return true;
            }
            catch { return false; }
        }
        public bool TryVender(string producto, out int precio)
        {
            precio = 0;
            if (precios.ContainsKey(producto))
            {
                precio = precios[producto];
                return true;
            }
            return false;
        }
    }
}
