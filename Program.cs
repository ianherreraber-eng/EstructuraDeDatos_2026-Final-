using System;

// 1. NUESTRO TIPO DE DATO PERSONALIZADO (Vive en el Stack, es ultraligero)
public readonly struct CoordenadaGPS
{
    public double Latitud { get; }
    public double Longitud { get; }

    // Constructor con validación estricta
    public CoordenadaGPS(double lat, double lon)
    {
        if (lat < -90 || lat > 90)
            throw new ArgumentOutOfRangeException(nameof(lat), "La latitud debe estar entre -90 y 90 grados.");
        if (lon < -180 || lon > 180)
            throw new ArgumentOutOfRangeException(nameof(lon), "La longitud debe estar entre -180 y 180 grados.");

        Latitud = lat;
        Longitud = lon;
    }

    public void ImprimirUbicacion()
    {
        Console.WriteLine($"[GPS] Latitud: {Latitud:F4}°, Longitud: {Longitud:F4}°");
    }
}

class Clase10_Structs
{
    static void Main()
    {
        Console.WriteLine("=== Sistema de Telemetría GPS ===\n");

        try
        {
            // 2. Creando coordenadas válidas
            Console.WriteLine("--- Coordenada 1 (Sede Corporativa) ---");
            CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332);
            c1.ImprimirUbicacion();

            // Demostrando copia por valor (Stack)
            Console.WriteLine("\n--- Coordenada 2 (Copia Independiente) ---");
            CoordenadaGPS c2 = c1; 
            // Aunque cambiemos de variable, como es un struct, c1 no se afecta.
            c2 = new CoordenadaGPS(52.5200, 13.4050); 
            c2.ImprimirUbicacion();

            // 3. Forzando un error de telemetría
            Console.WriteLine("\n--- Recibiendo datos corruptos del satélite... ---");
            // Intentamos meter una latitud imposible (150 grados)
            CoordenadaGPS coordError = new CoordenadaGPS(150.0, -99.1332);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡Alerta de Sistema! Se interceptó una coordenada inválida.");
            Console.WriteLine($"Detalle técnico: {ex.Message}");
            Console.ResetColor();
        }
    }
}