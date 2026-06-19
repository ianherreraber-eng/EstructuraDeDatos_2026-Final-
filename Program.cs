using System;
using System.Collections.Generic;
using System.Linq; // Necesario para usar consultas avanzadas

// 1. NUESTRO MODELO DE DATOS
public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    // Este método nos ayuda a imprimir el producto bonito en consola
    public override string ToString()
    {
        return $"[{ID}] {Nombre} - ${Precio:F2} | Stock: {Cantidad}";
    }
}

class Clase3_Colecciones
{
    static void Main()
    {
        Console.WriteLine("=== Sistema de Inventario ===\n");

        // 2. CREACIÓN DE LA LISTA DINÁMICA
        // Inicializamos con 4 productos y luego agregamos un quinto
        List<Producto> inventario = new List<Producto>
        {
            new Producto { ID = 1, Nombre = "Lenovo ThinkPad T14 Gen 2", Precio = 25000.00, Cantidad = 10 },
            new Producto { ID = 2, Nombre = "Mouse Inalámbrico Razer", Precio = 899.00, Cantidad = 25 },
            new Producto { ID = 3, Nombre = "Teclado Mecánico", Precio = 1299.00, Cantidad = 0 },
            new Producto { ID = 4, Nombre = "Monitor Samsung 24\"", Precio = 4500.00, Cantidad = 5 }
        };
        // Agregando con el método .Add()
        inventario.Add(new Producto { ID = 5, Nombre = "Audífonos Sony", Precio = 1200.00, Cantidad = 0 });

        // 3. CONSULTAS LINQ (Ordenamiento y Filtrado)
        Console.WriteLine("--- Productos ordenados por precio (Mayor a Menor) ---");
        var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
        porPrecio.ForEach(p => Console.WriteLine(p));

        Console.WriteLine("\n--- Productos Agotados ---");
        var agotados = inventario.Where(p => p.Cantidad == 0).ToList();
        agotados.ForEach(p => Console.WriteLine(p));

        // 4. DICCIONARIO (Búsqueda hiper-rápida)
        // Convertimos la lista a Diccionario usando el ID como llave
        Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

        Console.Write("\nIngresa el ID del producto a buscar (ej. 3): ");
        if (int.TryParse(Console.ReadLine(), out int idBuscado))
        {
            // TryGetValue busca la llave sin romper el programa si no existe
            if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"¡Encontrado!: {encontrado.Nombre}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El ID no existe en el catálogo.");
                Console.ResetColor();
            }
        }
    }
}