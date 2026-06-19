using System;

class Clase1_Poligonos
{
    // 1. EL MAIN: Es el director de la orquesta. Él no toca los instrumentos, 
    // solo manda a llamar a las otras funciones en orden.
    static void Main()
    {
        Console.WriteLine("=== Sistema de Cálculo Geométrico ===");
        
        int lados = SeleccionarPoligono();
        var (lado, apotema) = PedirDatos();
        
        double area = CalcularArea(lados, lado, apotema);
        Console.WriteLine($"\nEl área del polígono de {lados} lados es: {area:F2}");
    }

    // 2. FUNCIÓN PARA LOS LADOS
    static int SeleccionarPoligono()
    {
        int lados;
        // El "do-while" es una trampa. Obliga a repetir la pregunta MIENTRAS 
        // lo que escriba el usuario NO sea un número (!int.TryParse) o sea menor a 3.
        do
        {
            Console.Write("Ingrese el número de lados del polígono (ej. 5 para pentágono): ");
        } while (!int.TryParse(Console.ReadLine(), out lados) || lados < 3);
        
        return lados;
    }

    // 3. FUNCIÓN PARA MEDIDAS
    // Usamos una "Tupla" (double, double) que es como una caja que nos permite 
    // devolver dos valores al mismo tiempo en lugar de solo uno.
    static (double, double) PedirDatos()
    {
        double lado, apotema;
        
        do
        {
            Console.Write("Ingrese la medida del lado (positivo): ");
        } while (!double.TryParse(Console.ReadLine(), out lado) || lado <= 0);

        do
        {
            Console.Write("Ingrese la medida de la apotema (positivo): ");
        } while (!double.TryParse(Console.ReadLine(), out apotema) || apotema <= 0);

        return (lado, apotema); // Devolvemos la caja con los dos datos
    }

    // 4. FUNCIÓN MATEMÁTICA
    static double CalcularArea(int lados, double lado, double apotema)
    {
        double perimetro = lados * lado;
        return (perimetro * apotema) / 2;
    }
}