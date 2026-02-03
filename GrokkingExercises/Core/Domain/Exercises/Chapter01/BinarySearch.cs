namespace GrokkingExercises.Core.Domain.Exercises.Chapter01;

/// <summary>
/// Implementação básica de busca binária.
/// Complexidade: O(log n) - muito mais eficiente que busca linear O(n).
/// </summary>
public class BinarySearchClass
{
    /// <summary>
    /// Busca binária em uma lista ordenada.
    /// </summary>
    /// <param name="sortedList">Lista ordenada de inteiros</param>
    /// <param name="target">Valor a ser buscado</param>
    /// <returns>Índice do elemento ou -1 se não encontrado</returns>
    public static int BinarySearch(int[] sortedList, int target)
    {
        var left = 0;
        var right = sortedList.Length - 1;

        while (left <= right)
        {
            // Calcula o meio evitando overflow
            var mid = left + (right - left) / 2;

            if (sortedList[mid] == target)
            {
                return mid; // Encontrou!
            }
            else if (sortedList[mid] < target)
            {
                left = mid + 1; // Busca na metade direita
            }
            else
            {
                right = mid - 1; // Busca na metade esquerda
            }
        }

        return -1; // Não encontrado
    }
}