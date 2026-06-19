using System;

class Clase4_Recursividad
{
    static void Main()
    {
        Console.WriteLine("=== Algoritmos Recursivos ===\n");

        // --- MÓDULO 1: FACTORIAL ---
        Console.Write("Ingresa un número para calcular su factorial (ej. 5): ");
        if (int.TryParse(Console.ReadLine(), out int numFactorial))
        {
            try
            {
                // Intentamos calcularlo
                long resultado = CalcularFactorial(numFactorial);
                Console.WriteLine($"El factorial de {numFactorial}! es = {resultado}");
            }
            catch (ArgumentException ex)
            {
                // Si la función lanza un error, lo atrapamos aquí sin que se cierre el programa
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }

        // --- MÓDULO 2: FIBONACCI ---
        Console.Write("\nIngresa la posición de la secuencia de Fibonacci a buscar (ej. 6): ");
        if (int.TryParse(Console.ReadLine(), out int numFib))
        {
            try
            {
                long fib = GenerarFibonacci(numFib);
                Console.WriteLine($"El número en la posición Fibonacci({numFib}) es = {fib}");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    // FUNCIÓN 1: FACTORIAL
    static long CalcularFactorial(int n)
    {
        // 1. Validación (Defensa del programa)
        if (n < 0) throw new ArgumentException("No existe el factorial de números negativos.");
        
        // 2. CASO BASE (Cuándo detenerse)
        if (n == 0 || n == 1) return 1;
        
        // 3. CASO RECURSIVO (La función se llama a sí misma con n-1)
        return n * CalcularFactorial(n - 1);
    }

    // FUNCIÓN 2: FIBONACCI
    static long GenerarFibonacci(int n)
    {
        // 1. Validación
        if (n < 0) throw new ArgumentException("La posición debe ser un número positivo.");
        
        // 2. CASOS BASE (Tiene dos casos base)
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        // 3. CASO RECURSIVO DOBLE (Suma de los dos anteriores)
        return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
    }
}