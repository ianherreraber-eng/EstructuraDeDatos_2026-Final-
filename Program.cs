using System;
using System.Numerics; 

class Clase8_Overflow
{
    static void Main()
    {
        Console.WriteLine("=== Demostración de Desbordamiento (Overflow) ===\n");
        Console.WriteLine(" N | Factorial (Recursivo) | Factorial (Iterativo)");
        Console.WriteLine("--------------------------------------------------");

        for (int i = 1; i <= 15; i++)
        {
            int resultadoRecursivo = FactorialInt(i);
            int resultadoIterativo = FactorialIterativo(i);
            
            if (i >= 13) Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine($"{i,2} | {resultadoRecursivo,21} | {resultadoIterativo,21}");
            Console.ResetColor();
        }

        Console.WriteLine("\n=== Solución Profesional con BigInteger ===");
        
        BigInteger numeroMasivo = 100;
        BigInteger resultadoSeguro = FactorialProfesional(numeroMasivo);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nEl factorial de 100! tiene más de 150 dígitos:");
        Console.WriteLine(resultadoSeguro);
        Console.ResetColor();
    }

    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1) return 1;
        return n * FactorialInt(n - 1);
    }

    static int FactorialIterativo(int n)
    {
        int resultado = 1;
        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }
        return resultado;
    }

    static BigInteger FactorialProfesional(BigInteger n)
    {
        if (n == 0 || n == 1) return BigInteger.One;
        return n * FactorialProfesional(n - 1);
    }
}