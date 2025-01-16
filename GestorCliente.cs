using AppConsola.Constructores;
using AppConsola.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola
{
    public class GestorCliente
    {
        public static void registrarCliente()
        {
            using(var contexto = new ContextoBd())
            {
                var clienteNuevo = Ctores.ConsClientes();
                contexto.Clientes.Add(clienteNuevo);
                contexto.SaveChanges();
                Console.WriteLine("Cliente agregado con exito!");
            }
        }

        public static void sumarPuntos(int idCliente, int puntos)
        {
            using (var contexto = new ContextoBd())
            {
                var cliente = contexto.Clientes.First(i => i.IdCliente == idCliente);

                if(cliente != null)
                {
                    cliente.Puntos += puntos;
                    contexto.SaveChanges();
                }
            }
        }

        public static void restarPuntos(int idCliente, int puntos)
        {
            using (var contexto = new ContextoBd())
            {
                var cliente = contexto.Clientes.First(i => i.IdCliente == idCliente);

                if (cliente != null && cliente.Puntos > puntos)
                {
                    cliente.Puntos -= puntos;
                    contexto.SaveChanges();
                    Console.WriteLine("Puntos restados con exito");
                }
                else
                {
                    Console.WriteLine("El cliente no fue encontrado");
                    Console.WriteLine("O los puntos no son los suficientes");
                }
            }
        }

        public static void consultarPuntos(int id)
        {
            using (var contexto = new ContextoBd())
            {
                var cliente = contexto.Clientes.First(i => i.IdCliente == id);

                if(cliente != null)
                {
                    Console.WriteLine($"Puntos: {cliente.Puntos}");
                }
            }
        }

        public static void listarClientes()
        {
            using(var contexto = new ContextoBd())
            {
                var clientes = contexto.Clientes.ToList();
                foreach(var cliente in clientes)
                {
                    Console.WriteLine($"Id: {cliente.IdCliente} - Nombre: {cliente.Nombre}");
                }
            }
        }
    }
}
