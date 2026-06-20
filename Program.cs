using System;
using System.Diagnostics; // Librería obligatoria para usar Stopwatch

class Clase9_Memoization
{
    static void Main()
    {
        Console.WriteLine("=== Benchmark: Fuerza Bruta vs Memoization ===\n");
        
        int n = 40; // Prueba con 40. Si pones 50 en Fuerza Bruta, tu PC podría congelarse.
        Stopwatch sw = new Stopwatch();

        // --- MÉTODO 1: FUERZA BRUTA ---
        Console.WriteLine($"Calculando Fibonacci({n}) con Fuerza Bruta (Espera unos segundos)...");
        sw.Restart();
        long resultadoInseguro = FibonacciInseguro(n);
        sw.Stop();
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[O(2^n)] Resultado: {resultadoInseguro} | Tiempo: {sw.ElapsedMilliseconds} ms\n");
        Console.ResetColor();

        // --- MÉTODO 2: MEMOIZATION (Caché) ---
        // Inicializamos el arreglo de caché con puros -1 (que significa "vacío")
        long[] cache = new long[n + 1];
        for (int i = 0; i <= n; i++) 
        {
            cache[i] = -1;
        }

        Console.WriteLine($"Calculando Fibonacci({n}) con Memoization...");
        sw.Restart();
        long resultadoPro = FibonacciPro(n, cache);
        sw.Stop();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[O(n)]   Resultado: {resultadoPro} | Tiempo: {sw.ElapsedMilliseconds} ms\n");
        Console.ResetColor();
    }

    // 1. Fuerza Bruta (Ineficiente, calcula lo mismo una y otra vez)
    public static long FibonacciInseguro(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }

    // 2. Memoization (Inteligente, guarda en caché)
    public static long FibonacciPro(int n, long[] cache)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        // ¡LA MAGIA!: Si el cálculo ya existe en el caché, devuélvelo inmediatamente
        if (cache[n] != -1) return cache[n];
        
        // Si no existe, calcúlalo y GUÁRDALO en el caché para el futuro
        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
        return cache[n];
    }
}