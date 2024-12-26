using AppConsola.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola
{
    public class GestorCompra
    {
        //En estos sistemas se afirma con 1 y se niega con 0
        
        public static void realizarCompra()
        {
            using(var contexto = new ContextoBd())
            {
                Console.Write("Ingrese 0 si no es cliente, 1 si lo es: ");
                int clienteSoN = int.Parse(Console.ReadLine());
                if (clienteSoN == 1)
                {
                    Console.Write("Ingrese Nombre: ");
                    string nombre = Console.ReadLine();
                    var cliente = contexto.Clientes.First(n => n.Nombre == nombre);

                    if(cliente != null)
                    {
                        decimal precio = pasarProductos();
                        cliente.Puntos += 1;
                        contexto.SaveChanges();
                        Console.WriteLine($"Total a pagar: {precio}");
                    }
                }
                else
                {
                    decimal precio = pasarProductos();
                    contexto.SaveChanges();
                    Console.WriteLine($"Total a pagar: {precio}");
                }
            }
        }

        private static decimal pasarProductos()
        {
            decimal total = 0;
            using (var contexto = new ContextoBd())
            {
                int n = 1;
                while (n != 0)
                {
                    Console.Write("Nombre producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    var producto = contexto.Productos.First(n => n.Nombre == nombre);

                    //Descripcion del producto
                    Console.WriteLine($"{producto.Nombre} - {producto.Categoria}");

                    producto.Stock -= cantidad;
                    total += (cantidad * producto.Precio);
                    Console.Write("Seguir: ");
                    n = int.Parse(Console.ReadLine());
                    contexto.SaveChanges();
                }
            }
            return total;
        }

    }
}
