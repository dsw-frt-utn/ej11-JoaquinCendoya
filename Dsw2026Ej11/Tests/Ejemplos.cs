using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        CasoList casoList = new CasoList();
        Alumno a1 = new Alumno(1, "Ana", 8.5);
        Alumno a2 = new Alumno(2, "Juan", 9.0);
        Alumno a3 = new Alumno(3, "Pedro", 7.2);

        // Agregar 3 alumnos a la lista
        casoList.AgregarAlumno(a1);
        casoList.AgregarAlumno(a2);
        casoList.AgregarAlumno(a3);

        // Listar por consola los alumnos
        Console.WriteLine("--- Lista Inicial ---");
        foreach (var alumno in casoList.ObtenerLista())
        {
            Console.WriteLine(alumno);
        }

        // Buscar por nombre un alumno que exista y mostrar por consola
        Console.WriteLine("\n--- Busqueda Existente ---");
        var existente = casoList.BuscarAlumno("Ana");
        Console.WriteLine(existente != null ? existente.ToString() : "No existe");

        // Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
        Console.WriteLine("\n--- Busqueda Inexistente ---");
        var inexistente = casoList.BuscarAlumno("Carlos");
        Console.WriteLine(inexistente != null ? inexistente.ToString() : "No existe");

        // Eliminar un alumno y listar por consola los alumnos
        Console.WriteLine("\n--- Lista tras eliminar a Juan ---");
        casoList.EliminarAlumno(a2);
        foreach (var alumno in casoList.ObtenerLista())
        {
            Console.WriteLine(alumno);
        }

        // Eliminar el primer elemento de la lista y listar por consola los alumnos
        Console.WriteLine("\n--- Lista tras eliminar primera posición ---");
        casoList.EliminarAlumnoPosicion(0);
        foreach (var alumno in casoList.ObtenerLista())
        {
            Console.WriteLine(alumno);
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Dictionary<int, Alumno> dicAlumnos = new Dictionary<int, Alumno>();

        // Agregar 3 alumnos al diccionario
        dicAlumnos.Add(1, new Alumno(1, "Ana", 8.5));
        dicAlumnos.Add(2, new Alumno(2, "Juan", 9.0));
        dicAlumnos.Add(3, new Alumno(3, "Pedro", 7.2));

        // Listar por consola los alumnos
        Console.WriteLine("\n--- Diccionario Inicial ---");
        foreach (var kvp in dicAlumnos)
        {
            Console.WriteLine($"Clave: {kvp.Key} - {kvp.Value}");
        }

        // Buscar un alumno por clave y mostrar por consola
        Console.WriteLine("\n--- Busqueda de Clave Existente ---");
        if (dicAlumnos.TryGetValue(2, out Alumno? alumnoEncontrado))
        {
            Console.WriteLine(alumnoEncontrado);
        }
        else
        {
            Console.WriteLine("No existe");
        }

        // Buscar un alumno por clave, pero que no exista, y mostrar "No existe"
        Console.WriteLine("\n--- Busqueda de Clave Inexistente ---");
        if (dicAlumnos.TryGetValue(99, out Alumno? alumnoNoEncontrado))
        {
            Console.WriteLine(alumnoNoEncontrado);
        }
        else
        {
            Console.WriteLine("No existe");
        }

        // Eliminar un alumno por clave y listar por consola los alumnos
        Console.WriteLine("\n--- Diccionario tras eliminar clave 1 ---");
        dicAlumnos.Remove(1);
        foreach (var kvp in dicAlumnos)
        {
            Console.WriteLine($"Clave: {kvp.Key} - {kvp.Value}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        CasoLinq casoLinq = new CasoLinq();
        List<Libro> libros = Libro.CrearLista();

        Console.WriteLine("\n--- 1. Primer Libro ---");
        Console.WriteLine(casoLinq.GetPrimero(libros)?.Titulo ?? "No hay libros");

        Console.WriteLine("\n--- 2. Ultimo Libro ---");
        Console.WriteLine(casoLinq.GetUltimo(libros)?.Titulo ?? "No hay libros");

        Console.WriteLine("\n--- 3. Total Precios ---");
        Console.WriteLine((casoLinq.GetTotalPrecios(libros) ?? 0).ToString("C"));

        Console.WriteLine("\n--- 4. Promedio Precios ---");
        Console.WriteLine((casoLinq.GetPromedioPrecios(libros) ?? 0).ToString("C"));

        Console.WriteLine("\n--- 5. Libros con Id > 15 ---");
        foreach (var libro in casoLinq.GetListById(libros))
        {
            Console.WriteLine($"{libro.Id} - {libro.Titulo}");
        }

        Console.WriteLine("\n--- 6. Formato Moneda (Lista String) ---");
        foreach (var cadena in casoLinq.GetLibros(libros))
        {
            Console.WriteLine(cadena);
        }

        Console.WriteLine("\n--- 7. Libro Mayor Precio ---");
        Console.WriteLine(casoLinq.GetMayorPrecio(libros)?.Titulo ?? "No hay libros");

        Console.WriteLine("\n--- 8. Libro Menor Precio ---");
        Console.WriteLine(casoLinq.GetMenorPrecio(libros)?.Titulo ?? "No hay libros");

        Console.WriteLine("\n--- 9. Libros Mayor al Promedio ---");
        foreach (var libro in casoLinq.GetMayorPromedio(libros))
        {
            Console.WriteLine($"{libro.Titulo} ({libro.Precio:C})");
        }

        Console.WriteLine("\n--- 10. Libros Ordenados Descendente ---");
        foreach (var libro in casoLinq.GetLibrosOrdenados(libros))
        {
            Console.WriteLine(libro.Titulo);
        }
    }
}
