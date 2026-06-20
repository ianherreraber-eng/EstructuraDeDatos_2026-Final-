using System;

class Clase7_CallStack
{
    static void Main()
    {
        Console.WriteLine("=== Anatomía de la Recursividad (Call Stack) ===\n");
        
        // EJERCICIO A: Cuenta Regresiva Visual
        Console.WriteLine("--- Ejercicio A: Cuenta Regresiva Visual ---");
        ImprimirCuentaRegresiva(3);
        
        // EJERCICIO B: Suma Recursiva Segura
        Console.WriteLine("\n--- Ejercicio B: Suma Recursiva Segura ---");
        Console.Write("Introduce un número entero positivo para sumar hasta él: ");
        
        // Usamos TryParse para evitar que el programa truene si metes letras
        if (int.TryParse(Console.ReadLine(), out int numero) && numero > 0)
        {
            Console.WriteLine($"La suma recursiva desde 1 hasta {numero} es: {SumarHasta(numero)}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Entrada inválida. Debes ingresar un número entero mayor a 0.");
            Console.ResetColor();
        }
    }

    // FUNCIÓN DEL EJERCICIO A
    static void ImprimirCuentaRegresiva(int numero)
    {
        // 1. Caso Base: Cuando llegamos a 0, detenemos la recursión.
        if (numero < 1) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   ¡Despegue! (Caso Base Alcanzado)");
            Console.ResetColor();
            return;
        }
        
        // 2. Antes de la recursión (Se guarda en la memoria Stack)
        Console.WriteLine($"[APILANDO en memoria] Dejando en pausa n = {numero}");
        
        // 3. Llamada Recursiva
        ImprimirCuentaRegresiva(numero - 1); 
        
        // 4. Después de la recursión (Se libera de la memoria Stack)
        // NOTA: ¡Esta línea no se ejecuta hasta que el Caso Base se alcanza!
        Console.WriteLine($"[LIBERANDO de memoria] Terminando n = {numero}");
    }

    // FUNCIÓN DEL EJERCICIO B
    static int SumarHasta(int n)
    {
        // Caso Base
        if (n == 1) return 1; 
        
        // Caso Recursivo
        return n + SumarHasta(n - 1); 
    }
}