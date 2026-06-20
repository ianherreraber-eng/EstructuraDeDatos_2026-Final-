using System;
using System.Numerics; // ¡Librería clave para matemáticas a nivel empresarial!

class Clase8_Overflow
{
    static void Main()
    {
        Console.WriteLine("=== Demostración de Desbordamiento (Overflow) ===\n");
        Console.WriteLine(" N | Factorial (Recursivo) | Factorial (Iterativo)");
        Console.WriteLine("--------------------------------------------------");

        // 1. Demostrando el punto de quiebre del 'int'
        // El desbordamiento ocurre exactamente en n=13
        for (int i = 1; i <= 15; i++)
        {
            int resultadoRecursivo = FactorialInt(i);
            int resultadoIterativo = FactorialIterativo(i);
            
            // Si i >= 13, lo pintamos de rojo para evidenciar el error
            if (i >= 13) Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine($"{i,2} | {resultadoRecursivo,21} | {resultadoIterativo,21}");
            Console.ResetColor();
        }

        Console.WriteLine("\n=== Solución Profesional con BigInteger ===");
        
        // 2. Calculando un número masivo con seguridad
        BigInteger numeroMasivo = 100;
        BigInteger resultadoSeguro = FactorialProfesional(numeroMasivo);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nEl factorial de 100! tiene más de 150 dígitos:");
        Console.WriteLine(resultadoSeguro);
        Console.ResetColor();
    }

    // Método 1: Factorial clásico recursivo (Peligroso para números > 12)
    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1) return 1;
        return n * FactorialInt(n - 1);
    }

    // Método 2: Factorial con ciclo (Mismo problema de límite de memoria)
    static int FactorialIterativo(int n)
    {
        int resultado = 1;
        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }
        return resultado;
    }

    // Método 3: La solución empresarial inquebrantable
    static BigInteger FactorialProfesional(BigInteger n)
    {
        // BigInteger.One es el equivalente a poner un '1'
        if (n == 0 || n == 1) return BigInteger.One;
        return n * FactorialProfesional(n - 1);
    }
}