﻿namespace AppConsola
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            while (n == 0)
            {
                int opcion = Menu();

                switch (opcion)
                {
                    case 1:
                        GestorSuper.agregarProducto();
                        break;
                    case 2:
                        GestorSuper.contarProductos();
                        break;
                    case 3:
                        GestorCliente.registrarCliente();
                        break;
                    case 4:
                        GestorCliente.listarClientes();
                        break;
                    case 5:
                        GestorCompra.realizarCompra();
                        break;
                    case 6:
                        n = 1;
                        break;
                }
            }
        }

        static int Menu()
        {
            Console.WriteLine("1 - Agregar producto");
            Console.WriteLine("2 - Listar productos");
            Console.WriteLine("3 - Agregar cliente");
            Console.WriteLine("4 - Ver clientes");
            Console.WriteLine("5 - Realizar compra");
            Console.WriteLine("6 - Salir");
            int opcion = int.Parse(Console.ReadLine());
            return opcion;
        }
    }
}
