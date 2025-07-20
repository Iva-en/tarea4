using System;
using System.Collections.Generic;
using System.Linq;

public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }

    public void Mostrar()
    {
        Console.WriteLine($"{Id}    {Nombre}    {Telefono}    {Email}    {Direccion}");
    }
}

public class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();

    public void AgregarContacto()
    {
        int id = contactos.Count + 1;
        Console.Write("Digite el Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Digite el Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Digite el Email: ");
        string email = Console.ReadLine();
        Console.Write("Digite la dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto(id, nombre, telefono, email, direccion));
        Console.WriteLine("Contacto agregado exitosamente.");
    }

    public void VerContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos.");
            return;
        }

        Console.WriteLine("\nId    Nombre    Teléfono    Email    Dirección");
        Console.WriteLine("----------------------------------------------------");
        foreach (var c in contactos)
            c.Mostrar();
    }

    public void BuscarContacto()
    {
        Console.Write("Digite el Id del contacto a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = contactos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Console.WriteLine("\nResultado:");
                c.Mostrar();
            }
            else Console.WriteLine("Contacto no encontrado.");
        }
        else
        {
            Console.WriteLine("Id inválido.");
        }
    }

    public void EditarContacto()
    {
        Console.Write("Digite el Id del contacto a editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = contactos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Console.Write($"Nombre actual ({c.Nombre}), nuevo: ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoNombre)) c.Nombre = nuevoNombre;

                Console.Write($"Teléfono actual ({c.Telefono}), nuevo: ");
                string nuevoTelefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoTelefono)) c.Telefono = nuevoTelefono;

                Console.Write($"Email actual ({c.Email}), nuevo: ");
                string nuevoEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevoEmail)) c.Email = nuevoEmail;

                Console.Write($"Dirección actual ({c.Direccion}), nuevo: ");
                string nuevaDireccion = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevaDireccion)) c.Direccion = nuevaDireccion;

                Console.WriteLine("Contacto editado exitosamente.");
            }
            else Console.WriteLine("Contacto no encontrado.");
        }
        else
        {
            Console.WriteLine("Id inválido.");
        }
    }

    public void EliminarContacto()
    {
        Console.Write("Digite el Id del contacto a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var c = contactos.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Console.Write("¿Está seguro? (1. Sí / 2. No): ");
                if (Console.ReadLine() == "1")
                {
                    contactos.Remove(c);
                    Console.WriteLine("Contacto eliminado.");
                }
                else
                {
                    Console.WriteLine("Operación cancelada.");
                }
            }
            else Console.WriteLine("Contacto no encontrado.");
        }
        else
        {
            Console.WriteLine("Id inválido.");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda miAgenda = new Agenda();
        bool ejecutando = true;

        Console.WriteLine("Mi Agenda Perrón");
        Console.WriteLine("Bienvenido a tu lista de contactes");

        while (ejecutando)
        {
            Console.WriteLine("\n1. Agregar Contacto    2. Ver Contactos    3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto  5. Eliminar Contacto    6. Salir");
            Console.Write("Elige una opción: ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1: miAgenda.AgregarContacto(); break;
                    case 2: miAgenda.VerContactos(); break;
                    case 3: miAgenda.BuscarContacto(); break;
                    case 4: miAgenda.EditarContacto(); break;
                    case 5: miAgenda.EliminarContacto(); break;
                    case 6: ejecutando = false; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo.");
            }
        }

        Console.WriteLine("¡Gracias por usar la Agenda Perrón!");
    }
}
