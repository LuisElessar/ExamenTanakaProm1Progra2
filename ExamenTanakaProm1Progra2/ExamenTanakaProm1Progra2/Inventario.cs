using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTanakaProm1Progra2
{
    internal class Inventario<T>
    {
        private List<T> items = new List<T>();

        public void Agregar(T item)
        {
            items.Add(item);
            Console.WriteLine($"Se agregó {item} al inventario.");
        }

        public void Mostrar()
        {
            Console.WriteLine("Inventario:");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
