using System;
using System.Diagnostics; 

class Clase9_Memoization
{
    static void Main()
    {
        Console.WriteLine("=== Benchmark: Fuerza Bruta vs Memoization ===\n");
        
        int n = 40; 
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

    public static long FibonacciInseguro(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }

    public static long FibonacciPro(int n, long[] cache)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        
        if (cache[n] != -1) return cache[n];
        
        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
        return cache[n];
    }
}