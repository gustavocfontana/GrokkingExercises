namespace GrokkingExercises.Core.Domain.Exercises.Chapter01;

public class BinarySearchExercises
{
    // Exercicio 1.1 - Implementacao Basica
    // - Recebe uma lista ordenada e um alvo
    // - Retorna o indice do elemento ou −1 se não encontrado
    // - Use a abordagem iterativa ou recursiva
    // Exemplo:
    // busca_binaria([1, 3, 5, 7, 9, 11], 7) -> 3
    // busca_binaria([2, 4, 6, 8], 5) -> -1
    public int Exercise11_BinarySearch(int[] sortedList, int target)
    {
        return BinarySearchClass.BinarySearch(sortedList, target);
    }

    // Exercicio 1.2 - Busca com Estimativa
    // Você tem uma lista de 1 milhao de números ordenados.
    // Precisa encontrar um número especifico.
    // Quantas tentativas maximo você faria com busca binaria vs busca linear?
    // Dica: Pense sobre log2(1.000.000).
    public (int binarySearchMax, int linearSearchMax) Exercise12_MaxAttempts()
    {
        // Busca Linear: no pior caso, precisa verificar TODOS os elementos
        // Se o elemento estiver na ultima posicao ou nao existir, vai fazer 1.000.000 de tentativas
        int linearSearchMax = 1_000_000;

        // Busca Binaria: no pior caso, divide a lista pela metade a cada tentativa
        // Formula: log2(n) onde n = 1.000.000
        // log2(1.000.000) ≈ 19.93, arredondando para cima = 20 tentativas
        int binarySearchMax = (int)Math.Ceiling(Math.Log2(1_000_000));

        return (binarySearchMax, linearSearchMax);
    }

    // Exercicio 1.3 - Encontrar Primeiro Maior que X
    // Implemente uma funcao que encontra o primeiro número maior que X
    // numa lista ordenada usando busca binaria.
    public int Exercise13_FirstGreaterThanX(int[] sortedList, int x)
    {
        // Se a lista está vazia, não há elementos
        if (sortedList.Length == 0)
        {
            return -1;
        }

        int left = 0;
        int right = sortedList.Length - 1;
        int result = -1; // Guarda o índice do primeiro maior que X

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Se o elemento do meio é MAIOR que X
            if (sortedList[mid] > x)
            {
                result = mid; // Esse pode ser o resultado
                right = mid - 1; // Mas vamos buscar à esquerda para ver se tem um menor índice
            }
            else // sortedList[mid] <= x
            {
                left = mid + 1; // Precisamos ir para a direita
            }
        }

        return result;
    }

    // Exercicio 1.4 - Encontrar primeira ocorrencia (lista com duplicados)
    // Retorne o indice da primeira ocorrencia do alvo, ou -1 se nao encontrado.
    public int Exercise14_FirstOccurrence(int[] sortedList, int target)
    {
        int left = 0;
        int right = sortedList.Length - 1;
        int result = -1; // Guarda o índice da primeira ocorrência

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (sortedList[mid] == target)
            {
                result = mid; // Encontramos, mas pode ter outra à esquerda
                right = mid - 1; // Continua buscando à esquerda
            }
            else if (sortedList[mid] < target)
            {
                left = mid + 1; // Vai para a direita
            }
            else // sortedList[mid] > target
            {
                right = mid - 1; // Vai para a esquerda
            }
        }

        return result;
    }

    // Exercicio 1.5 - Encontrar ultima ocorrencia (lista com duplicados)
    // Retorne o indice da ultima ocorrencia do alvo, ou -1 se nao encontrado.
    public int Exercise15_LastOccurrence(int[] sortedList, int target)
    {
        int left = 0;
        int right = sortedList.Length - 1;
        int result = -1; // Guarda o índice da última ocorrência

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (sortedList[mid] == target)
            {
                result = mid; // Encontramos, mas pode ter outra à direita
                left = mid + 1; // Continua buscando à direita
            }
            else if (sortedList[mid] < target)
            {
                left = mid + 1; // Vai para a direita
            }
            else // sortedList[mid] > target
            {
                right = mid - 1; // Vai para a esquerda
            }
        }

        return result;
    }

    // Exercicio 1.6 - Menor elemento maior ou igual a X (lower bound)
    // Retorne o indice do menor elemento >= X, ou -1 se nao existir.
    public int Exercise16_LowerBound(int[] sortedList, int x)
    {
        if (sortedList.Length == 0)
        {
            return -1;
        }

        int left = 0;
        int right = sortedList.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Se o elemento é MAIOR OU IGUAL a X
            if (sortedList[mid] >= x)
            {
                result = mid; // Pode ser o resultado
                right = mid - 1; // Mas busca à esquerda para achar o primeiro
            }
            else // sortedList[mid] < x
            {
                left = mid + 1; // Precisa ir para direita
            }
        }

        return result;
    }

    // Exercicio 1.7 - Buscar em lista ordenada rotational
    // Retorne o indice do alvo numa lista ordenada rotational, ou −1.
    public int Exercise17_SearchRotated(int[] rotatedSortedList, int target)
    {
        int left = 0;
        int right = rotatedSortedList.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Se encontrou o target
            if (rotatedSortedList[mid] == target)
            {
                return mid;
            }

            // Determinar qual metade está ordenada
            // Se a metade esquerda está ordenada
            if (rotatedSortedList[left] <= rotatedSortedList[mid])
            {
                // Verificar se o target está na metade esquerda ordenada
                if (rotatedSortedList[left] <= target && target < rotatedSortedList[mid])
                {
                    right = mid - 1; // Buscar na esquerda
                }
                else
                {
                    left = mid + 1; // Buscar na direita
                }
            }
            // Senão, a metade direita está ordenada
            else
            {
                // Verificar se o target está na metade direita ordenada
                if (rotatedSortedList[mid] < target && target <= rotatedSortedList[right])
                {
                    left = mid + 1; // Buscar na direita
                }
                else
                {
                    right = mid - 1; // Buscar na esquerda
                }
            }
        }

        return -1; // Não encontrado
    }
}