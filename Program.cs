using System;

// 1. LA ESTRUCTURA DEL NODO
// Cada nodo es como una caja que guarda un valor y tiene dos conectores (izquierdo y derecho)
public class Nodo
{
    public int ID { get; set; }
    public string Dato { get; set; } = string.Empty;
    
    // Usamos el signo de interrogación (?) porque un hijo puede ser nulo (no existir aún)
    public Nodo? HijoIzquierdo { get; set; }
    public Nodo? HijoDerecho { get; set; }

    public Nodo(int id, string dato)
    {
        ID = id;
        Dato = dato;
    }
}

class Clase5_Arboles
{
    static void Main()
    {
        Console.WriteLine("=== Construcción de Árbol Binario ===\n");

        // 2. CREANDO LA RAÍZ
        Nodo? raiz = new Nodo(10, "Raíz Principal (Centro)");
        
        // 3. INSERTANDO DATOS (La lógica los acomodará automáticamente)
        raiz = InsertarNodo(raiz, new Nodo(5, "Rama Izquierda (Menor)"));
        raiz = InsertarNodo(raiz, new Nodo(15, "Rama Derecha (Mayor)"));
        raiz = InsertarNodo(raiz, new Nodo(3, "Hoja Extrema Izquierda"));
        raiz = InsertarNodo(raiz, new Nodo(7, "Hoja Interna Izquierda"));

        // 4. PRUEBA DE BÚSQUEDA
        Console.WriteLine("Buscando el ID 7...");
        string? resultado = BuscarNodo(raiz, 7);
        
        if (resultado != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"¡Encontrado! Dato: {resultado}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Nodo no encontrado.");
        }
        Console.ResetColor();
    }

    // FUNCIÓN PARA INSERTAR (Recursiva)
    public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
    {
        // CASO BASE: Si llegamos a un espacio vacío, ahí plantamos el nodo
        if (raiz == null) return nuevoNodo;
        
        // Si el nuevo ID es menor, vete por el camino de la izquierda
        if (nuevoNodo.ID < raiz.ID)
            raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
        // Si es mayor, vete por el camino de la derecha
        else if (nuevoNodo.ID > raiz.ID)
            raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
            
        return raiz;
    }

    // FUNCIÓN PARA BUSCAR RÁPIDO O(log n)
    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        // Si llegamos a un camino sin salida, el dato no existe
        if (raiz == null) return null;
        
        // ¡Lo encontramos!
        if (idTarget == raiz.ID) return raiz.Dato;
        
        // Si lo que busco es menor a donde estoy parado, descarto toda la rama derecha
        if (idTarget < raiz.ID)
            return BuscarNodo(raiz.HijoIzquierdo, idTarget);
        // Si es mayor, descarto toda la rama izquierda
        else
            return BuscarNodo(raiz.HijoDerecho, idTarget);
    }
}