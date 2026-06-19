using System;

class Clase2_Memoria
{
    static void Main()
    {
        Console.WriteLine("=== Demostración de Stack vs Heap ===");

        // 1. Value Type (Vive en el Stack)
        int miNumero = 10;
        
        // 2. Reference Type (Vive en el Heap)
        int[] miArreglo = { 1, 2, 3 };

        Console.WriteLine("\n--- ANTES DE LAS FUNCIONES ---");
        Console.WriteLine($"Número original: {miNumero}");
        Console.WriteLine($"Primer valor del arreglo original: {miArreglo[0]}");

        // Llamamos a las funciones
        CambiarValor(miNumero);
        CambiarReferencia(miArreglo);

        Console.WriteLine("\n--- DESPUÉS DE LAS FUNCIONES ---");
        // miNumero seguirá siendo 10 (la función modificó una copia)
        Console.WriteLine($"Número original: {miNumero}");
        // miArreglo[0] ahora será 100 (la función modificó la memoria real)
        Console.WriteLine($"Primer valor del arreglo original: {miArreglo[0]}");
    }

    // Esta función recibe una COPIA del número.
    static void CambiarValor(int x)
    {
        x = 100; // Esto solo afecta a la "x" local, no a "miNumero" del Main
    }

    // Esta función recibe la DIRECCIÓN de memoria del arreglo.
    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100; // Esto altera el arreglo original directamente en el Heap
    }
}