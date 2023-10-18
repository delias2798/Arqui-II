using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int N = 40000000; // (debe ser múltiplo de 4 y mayor que 500)

        float[] array1 = new float[N];
        float[] array2 = new float[N];

        for (int i = 0; i < N; i++)
        {
            array1[i] = (float)i;
            array2[i] = (float)(i * 2);
        }

        float result = 0;
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        for (int i = 0; i < N; i++)
        {
            result += array1[i] * array2[i];
        }
        stopwatch.Stop();

        Console.WriteLine($"Con N igual a: {N}");
        Console.WriteLine($"El producto punto es: {result}");
        Console.WriteLine($"Tiempo de ejecución (sin optimización): {stopwatch.Elapsed.TotalMilliseconds} ms");


        array1 = new float[N];
        array2 = new float[N];

        for (int i = 0; i < N; i++)
        {
            array1[i] = (float)i;
            array2[i] = (float)(i * 2);
        }

        Stopwatch stopwatch2 = new Stopwatch();
        stopwatch2.Start();
        result = VectorDotProduct.CalculateDotProduct(array1, array2);
        stopwatch.Stop();

        Console.WriteLine($"El producto punto es: {result}");
        Console.WriteLine($"Tiempo de ejecución con optimizacion de Intrinsics.X86: {stopwatch2.Elapsed.TotalMilliseconds} ms");
    }
}
