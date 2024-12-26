using AppConsola.Entidades;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola.Constructores
{
    public class Ctores
    {
        public static Productos ConsProducto()
        {
            
            Console.Write("Ingrese nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese stock del producto: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Ingrese categoria del producto: ");
            string categoria = Console.ReadLine();

            return new Productos(nombre,precio,stock,categoria);
        }

        public static Clientes ConsClientes()
        {
            Console.Write("Ingrese nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese apellido del cliente: ");
            string apellido = Console.ReadLine();

            Console.Write("Ingrese email del cliente: ");
            string email = Console.ReadLine();

            Console.Write("Ingrese telefono del cliente: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese puntos del cliente: ");
            int puntos = int.Parse(Console.ReadLine());

            return new Clientes(nombre, apellido, email, telefono, puntos);
        }
    }

    


    
}
