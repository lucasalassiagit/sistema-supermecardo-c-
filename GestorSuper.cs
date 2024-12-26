using AppConsola.Constructores;
using AppConsola.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AppConsola
{
    public class GestorSuper
    {
        // Agrega productos existentes y no existentes
        //  Cuenta con logica para detectar si existen o no
        public static void agregarProducto()
        {
            using(var contexto = new ContextoBd())
            {
                Console.Write("Ingrese Id producto: ");
                int id = int.Parse(Console.ReadLine());

                var producto = contexto.Productos.FirstOrDefault(p => p.IdProducto == id);

                if(producto != null)
                {
                    Console.WriteLine("El producto ya existe!");
                    Console.Write("Ingrese stock a renovar: ");
                    int stockRenovar = int.Parse(Console.ReadLine());
                    producto.Stock += stockRenovar;
                    contexto.SaveChanges();
                    Console.WriteLine("Stock actualizado");
                }
                else
                {
                    Console.WriteLine("Va a ingresar un producto nuevo");
                    var productoNuevo = Ctores.ConsProducto();
                    contexto.Productos.Add(productoNuevo);
                    contexto.SaveChanges();
                    Console.WriteLine("Producto agregado con exito!");
                }

            }
        }


        public static void contarProductos()
        {
            using(var contexto = new ContextoBd())
            {
                var productos = contexto.Productos.ToList();
                Console.WriteLine("Producto -  Stock");
                foreach(var product in productos)
                {
                    Console.WriteLine($"{product.Nombre} -  {product.Stock}");
                }
            }
        }

        
    }
}
