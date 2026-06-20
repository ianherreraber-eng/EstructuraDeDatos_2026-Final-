using System;

// MÓDULO 3: Clase para demostrar referencias
public class Alumno
{
    public string Nombre { get; set; } = string.Empty;
}

class Clase6_Modificadores
{
    static void Main()
    {
        Console.WriteLine("=== MÓDULO 1: Modificador 'ref' ===");
        int x = 10;
        int y = 25;
        Console.WriteLine($"Antes del intercambio: x = {x}, y = {y}");
        
        // Pasamos las variables por referencia (su dirección en memoria)
        Intercambiar(ref x, ref y);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Después del intercambio: x = {x}, y = {y}\n");
        Console.ResetColor();

        Console.WriteLine("=== MÓDULO 2: Modificador 'out' ===");
        // 'resto' no necesita estar inicializada antes, la función la creará
        int cociente = CalcularYValidar(17, 5, out int resto);
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"17 / 5 = Cociente: {cociente}, Residuo: {resto}\n");
        Console.ResetColor();

        Console.WriteLine("=== MÓDULO 3: Referencias de Objetos ===");
        Alumno alumno1 = new Alumno { Nombre = "Dany" };
        
        // ¡Atención! Esto NO saca fotocopia, solo comparte la dirección de memoria
        Alumno alumno2 = alumno1; 
        
        Console.WriteLine($"Nombre original en alumno1: {alumno1.Nombre}");
        Console.WriteLine("Cambiando el nombre en alumno2 a '3Treum'...");
        alumno2.Nombre = "3Treum";
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        // Cambiar alumno2 afectó a alumno1 porque son la misma entidad en el Heap
        Console.WriteLine($"Nuevo nombre en alumno1: {alumno1.Nombre}\n");
        Console.ResetColor();
    }

    // FUNCIÓN 1: Requiere 'ref' para alterar la memoria original
    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // FUNCIÓN 2: Requiere 'out' para obligar a devolver el residuo
    static int CalcularYValidar(int dividendo, int divisor, out int residuo)
    {
        residuo = dividendo % divisor; // Obligatorio asignarlo antes de salir
        return dividendo / divisor;
    }
}