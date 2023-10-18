using System;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

public class VectorDotProduct
{
    public static float CalculateDotProduct(float[] array1, float[] array2)
    {
        int N = array1.Length;
        //Con simdLength se obtiene el tamaño del registro dsimd 
        int simdLength = Vector<float>.Count; 

        // Verifica si el tamaño de los arreglos es un multiplo del tamaño del registro simd
        if (N % simdLength != 0)
            throw new ArgumentException("El tamaño de los arreglos debe ser múltiplo del tamaño del registro SIMD.");

        Vector<float> resultVector = Vector<float>.Zero; // Vector de ceros para el resultado

        // Bucle principal que procesa los arreglos en bloques SIMD
        for (int i = 0; i < N; i += simdLength)
        {
            // Crea dos vectorres SIMD a partir de un bloque de array1 y de array2
            Vector<float> vector1 = new Vector<float>(array1, i); 
            Vector<float> vector2 = new Vector<float>(array2, i); 
            resultVector += vector1 * vector2; // Realiza una multiplicación SIMD entre vestores y acumula el resultado en resultVector
        }

        float result = resultVector[0]; // Obtiene el valor del primer elemento del vector resultante

        // Suma los elementos restantes del vector resultante
        for (int i = 1; i < simdLength; i++)
        {
            result += resultVector[i];
        }

        return result;
    }
}
