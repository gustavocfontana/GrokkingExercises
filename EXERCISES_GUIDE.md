# Guia Completo - Exercícios de Binary Search

Este guia explica **passo a passo** como resolver cada exercício de busca binária.

---

## 📚 Conceitos Fundamentais

### O que é Binary Search?

Binary Search (Busca Binária) é um algoritmo eficiente para encontrar um elemento em uma **lista ordenada**.

**Ideia Principal**: Dividir a lista pela metade a cada iteração.

```
Lista: [1, 3, 5, 7, 9, 11, 13]
Procurando: 7

Passo 1: Verifica o meio (índice 3, valor 7) → ENCONTROU!
```

**Complexidade**:
- Busca Linear: O(n) - pode precisar verificar todos os elementos
- Busca Binária: O(log n) - divide pela metade a cada passo

**Exemplo prático**:
- Lista com 1.000.000 de elementos
- Busca Linear: até 1.000.000 comparações
- Busca Binária: até 20 comparações! 🚀

---

## Exercício 1.1 - Binary Search Básico

### 📝 Problema
Encontre o índice de um elemento em uma lista ordenada. Retorne -1 se não existir.

### 💡 Como Pensar

1. **Definir os limites**: `left` (início) e `right` (fim) da área de busca
2. **Calcular o meio**: `mid = left + (right - left) / 2`
3. **Comparar**:
   - Se `sortedList[mid] == target` → Encontrou!
   - Se `sortedList[mid] < target` → Buscar na metade direita
   - Se `sortedList[mid] > target` → Buscar na metade esquerda
4. **Repetir** até encontrar ou não haver mais elementos

### 🔍 Exemplo Visual

```
Lista: [1, 3, 5, 7, 9, 11, 13]
Target: 11

Iteração 1:
left=0, right=6, mid=3
[1, 3, 5, |7|, 9, 11, 13]
7 < 11 → Vai para direita

Iteração 2:
left=4, right=6, mid=5
[9, |11|, 13]
11 == 11 → ENCONTROU no índice 5!
```

### 💻 Implementação

```csharp
public int BinarySearch(int[] sortedList, int target)
{
    int left = 0;
    int right = sortedList.Length - 1;

    while (left <= right)
    {
        // Calcula o meio (evita overflow)
        int mid = left + (right - left) / 2;

        if (sortedList[mid] == target)
        {
            return mid; // Encontrou!
        }
        else if (sortedList[mid] < target)
        {
            left = mid + 1; // Busca na direita
        }
        else
        {
            right = mid - 1; // Busca na esquerda
        }
    }

    return -1; // Não encontrou
}
```

### ⚠️ Detalhes Importantes

**Por que `mid = left + (right - left) / 2`?**
- Evita overflow em listas muito grandes
- Equivalente a `(left + right) / 2`, mas mais seguro

**Por que `while (left <= right)`?**
- Permite buscar até quando houver exatamente 1 elemento (`left == right`)
- Se usar `<` (sem igual), pode perder o último elemento

---

## Exercício 1.2 - Estimativa de Tentativas

### 📝 Problema
Para uma lista de 1.000.000 de elementos, quantas tentativas seriam necessárias no **pior caso**?

### 💡 Raciocínio

**Busca Linear**:
- Verifica elemento por elemento
- Pior caso: elemento está no final ou não existe
- Tentativas: **1.000.000**

**Busca Binária**:
- Divide pela metade a cada iteração
- Fórmula: `log₂(n)` onde n = tamanho da lista
- Tentativas: `log₂(1.000.000) ≈ 20`

### 💻 Implementação

```csharp
public (int binarySearchMax, int linearSearchMax) Exercise12_MaxAttempts()
{
    int linearSearchMax = 1_000_000; // Pior caso: verifica todos

    // log₂(1.000.000) = log(1.000.000) / log(2) ≈ 19.93 → 20
    int binarySearchMax = (int)Math.Ceiling(Math.Log2(1_000_000));

    return (binarySearchMax, linearSearchMax);
}
```

### 📊 Comparação

| Tamanho | Linear | Binária | Diferença |
|---------|--------|---------|-----------|
| 100 | 100 | 7 | 14x |
| 1.000 | 1.000 | 10 | 100x |
| 1.000.000 | 1.000.000 | 20 | 50.000x |
| 1.000.000.000 | 1.000.000.000 | 30 | 33M x |

---

## Exercício 1.3 - Primeiro Maior que X

### 📝 Problema
Encontre o **primeiro** elemento que seja **maior** que X (não igual, só maior).

### 💡 Diferença da Busca Básica

- Busca básica: para quando encontra
- Este exercício: **continua buscando** mesmo quando encontra um candidato

### 🎯 Estratégia

1. Use uma variável `result` para guardar o melhor candidato
2. Quando encontrar um elemento maior que X:
   - Guarde o índice em `result`
   - Continue buscando à **esquerda** (pode ter um índice menor)
3. Quando o elemento for ≤ X:
   - Vá para a **direita**

### 🔍 Exemplo Visual

```
Lista: [2, 4, 6, 8, 10, 12]
X = 5

Iteração 1: mid=2 (valor 6)
6 > 5 → result = 2, busca à esquerda

Iteração 2: mid=0 (valor 2)
2 ≤ 5 → busca à direita

Iteração 3: mid=1 (valor 4)
4 ≤ 5 → busca à direita

Fim: result = 2 (primeiro maior que 5 é o 6 no índice 2)
```

### 💻 Implementação

```csharp
public int Exercise13_FirstGreaterThanX(int[] sortedList, int x)
{
    if (sortedList.Length == 0)
        return -1;

    int left = 0;
    int right = sortedList.Length - 1;
    int result = -1; // Guarda o índice do candidato

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (sortedList[mid] > x)
        {
            result = mid; // Candidato encontrado
            right = mid - 1; // Busca à esquerda por um índice menor
        }
        else // sortedList[mid] <= x
        {
            left = mid + 1; // Vai para direita
        }
    }

    return result;
}
```

### 🔑 Ponto-Chave

**Por que continuar buscando à esquerda?**
- Pode haver outro elemento maior que X com índice menor
- Exemplo: `[7, 8, 9]` com X=5
  - Se parar no 9, perderia o 7 que é o primeiro

---

## Exercício 1.4 - Primeira Ocorrência

### 📝 Problema
Em uma lista com **duplicatas**, encontre o índice da **primeira** ocorrência do target.

### 💡 Desafio

```
Lista: [1, 2, 2, 2, 3, 4]
Target: 2

Busca binária básica pode retornar índice 1, 2 ou 3
Queremos sempre: índice 1 (primeira ocorrência)
```

### 🎯 Estratégia

1. Quando encontrar o target:
   - **NÃO pare!**
   - Guarde o índice como candidato
   - Continue buscando à **esquerda**
2. Isso garante encontrar a primeira ocorrência

### 🔍 Exemplo Visual

```
Lista: [1, 2, 2, 2, 3, 4]
Target: 2

Iteração 1: mid=2 (valor 2)
Encontrou! result=2, busca à esquerda

Iteração 2: mid=0 (valor 1)
1 < 2 → busca à direita

Iteração 3: mid=1 (valor 2)
Encontrou! result=1, busca à esquerda

Fim: result=1 (primeira ocorrência)
```

### 💻 Implementação

```csharp
public int Exercise14_FirstOccurrence(int[] sortedList, int target)
{
    int left = 0;
    int right = sortedList.Length - 1;
    int result = -1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (sortedList[mid] == target)
        {
            result = mid; // Encontrou, mas pode ter outra à esquerda
            right = mid - 1; // CONTINUA buscando à esquerda
        }
        else if (sortedList[mid] < target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }

    return result;
}
```

---

## Exercício 1.5 - Última Ocorrência

### 📝 Problema
Encontre o índice da **última** ocorrência do target.

### 💡 Diferença do 1.4

- Exercício 1.4: busca à **esquerda** após encontrar
- Exercício 1.5: busca à **direita** após encontrar

### 🎯 Estratégia

Idêntica ao 1.4, mas inverte a direção:
1. Quando encontrar: vá para **direita**
2. Isso garante encontrar a última ocorrência

### 🔍 Exemplo Visual

```
Lista: [1, 2, 2, 2, 3, 4]
Target: 2

Iteração 1: mid=2 (valor 2)
Encontrou! result=2, busca à DIREITA

Iteração 2: mid=4 (valor 3)
3 > 2 → busca à esquerda

Iteração 3: mid=3 (valor 2)
Encontrou! result=3, busca à DIREITA

Fim: result=3 (última ocorrência)
```

### 💻 Implementação

```csharp
public int Exercise15_LastOccurrence(int[] sortedList, int target)
{
    int left = 0;
    int right = sortedList.Length - 1;
    int result = -1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (sortedList[mid] == target)
        {
            result = mid;
            left = mid + 1; // CONTINUA buscando à DIREITA
        }
        else if (sortedList[mid] < target)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }

    return result;
}
```

---

## Exercício 1.6 - Lower Bound

### 📝 Problema
Encontre o menor elemento que seja **maior OU IGUAL** a X.

### 💡 Diferença do 1.3

- Exercício 1.3: apenas **maior** (>)
- Exercício 1.6: **maior ou igual** (≥)

### 🎯 Quando Usar

Lower bound é útil para:
- Encontrar inserção em lista ordenada
- Range queries (consultas de intervalo)
- Funções de busca em STL/C++ (`std::lower_bound`)

### 🔍 Exemplos

```
Lista: [2, 4, 6, 8, 10]

X = 5 → Retorna índice 2 (6, primeiro ≥ 5)
X = 6 → Retorna índice 2 (6, é igual!)
X = 1 → Retorna índice 0 (2, primeiro ≥ 1)
X = 11 → Retorna -1 (não existe ≥ 11)
```

### 💻 Implementação

```csharp
public int Exercise16_LowerBound(int[] sortedList, int x)
{
    if (sortedList.Length == 0)
        return -1;

    int left = 0;
    int right = sortedList.Length - 1;
    int result = -1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        if (sortedList[mid] >= x) // MAIOR OU IGUAL (mudança aqui!)
        {
            result = mid;
            right = mid - 1; // Busca à esquerda
        }
        else
        {
            left = mid + 1;
        }
    }

    return result;
}
```

### 🔑 Comparação 1.3 vs 1.6

| Exercício | Condição | X=6 em [2,4,6,8,10] |
|-----------|----------|---------------------|
| 1.3 | `> x` | Retorna índice 3 (8) |
| 1.6 | `>= x` | Retorna índice 2 (6) |

---

## Exercício 1.7 - Busca em Lista Rotacionada

### 📝 Problema
Buscar elemento em uma lista ordenada que foi **rotacionada**.

### 💡 O que é Rotação?

```
Lista Original:    [1, 2, 3, 4, 5, 6, 7]
                        ↓ Rotaciona 3 posições
Lista Rotacionada: [4, 5, 6, 7, 1, 2, 3]
                    ↑ordenada↑ ↑ordenada↑
```

**Propriedade**: A lista tem **duas partes ordenadas**.

### 🎯 Estratégia

1. **Identificar qual metade está ordenada**
2. **Verificar se o target está nessa metade ordenada**
3. **Decidir para onde ir** baseado nisso

### 🔍 Como Identificar a Metade Ordenada?

```
Lista: [4, 5, 6, 7, 1, 2, 3]
        L     M        R

Se sortedList[L] <= sortedList[M]:
    → Metade esquerda está ordenada [4,5,6,7]
Senão:
    → Metade direita está ordenada [1,2,3]
```

### 📋 Passo a Passo

**Caso 1**: Metade esquerda ordenada
```
[4, 5, 6, 7, | 1, 2, 3]
 L     M       R

Se L <= target < M:
    → Target está na esquerda ordenada
Senão:
    → Target pode estar na direita
```

**Caso 2**: Metade direita ordenada
```
[6, 7, | 1, 2, 3, 4, 5]
 L  M          R

Se M < target <= R:
    → Target está na direita ordenada
Senão:
    → Target pode estar na esquerda
```

### 🔍 Exemplo Completo

```
Lista: [4, 5, 6, 7, 1, 2, 3]
Target: 2

Iteração 1:
L=0, R=6, M=3 (valor 7)
[4, 5, 6, |7|, 1, 2, 3]
4 <= 7 → esquerda ordenada
target 2 não está em [4,7] → vai para direita

Iteração 2:
L=4, R=6, M=5 (valor 2)
[1, |2|, 3]
1 <= 2 → esquerda ordenada
target 2 está em [1,2] → ENCONTROU!

Resultado: índice 5
```

### 💻 Implementação

```csharp
public int Exercise17_SearchRotated(int[] rotatedSortedList, int target)
{
    int left = 0;
    int right = rotatedSortedList.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2;

        // Encontrou?
        if (rotatedSortedList[mid] == target)
            return mid;

        // Qual metade está ordenada?
        if (rotatedSortedList[left] <= rotatedSortedList[mid])
        {
            // Esquerda está ordenada
            // Target está nessa metade ordenada?
            if (rotatedSortedList[left] <= target && target < rotatedSortedList[mid])
            {
                right = mid - 1; // Sim, busca à esquerda
            }
            else
            {
                left = mid + 1; // Não, busca à direita
            }
        }
        else
        {
            // Direita está ordenada
            // Target está nessa metade ordenada?
            if (rotatedSortedList[mid] < target && target <= rotatedSortedList[right])
            {
                left = mid + 1; // Sim, busca à direita
            }
            else
            {
                right = mid - 1; // Não, busca à esquerda
            }
        }
    }

    return -1; // Não encontrado
}
```

### ⚠️ Cuidados Especiais

**Por que `<=` em `sortedList[left] <= sortedList[mid]`?**
- Caso especial: quando `left == mid` (lista de 1 elemento)
- Garante que sempre identifica uma metade como ordenada

**Casos limites testados**:
- Lista sem rotação: `[1, 2, 3, 4, 5]`
- Um elemento: `[5]`
- Dois elementos: `[2, 1]`

---

## 🎯 Resumo Comparativo

| Exercício | Quando Encontra | Direção | Condição |
|-----------|-----------------|---------|----------|
| 1.1 | Para | - | `== target` |
| 1.3 | Continua | Esquerda | `> x` |
| 1.4 | Continua | Esquerda | `== target` |
| 1.5 | Continua | Direita | `== target` |
| 1.6 | Continua | Esquerda | `>= x` |
| 1.7 | Para | Dinâmica | Identifica metade |

---

## 💡 Dicas Gerais

### 1. Sempre use `mid = left + (right - left) / 2`
Evita overflow em listas grandes.

### 2. Padrão "Candidato"
Quando precisa do "primeiro" ou "último", use:
```csharp
int result = -1; // Guarda candidato
// ... dentro do loop
result = mid; // Atualiza candidato
// Continua buscando
```

### 3. Direção após encontrar
- **Primeira** ocorrência → busca **esquerda** (`right = mid - 1`)
- **Última** ocorrência → busca **direita** (`left = mid + 1`)

### 4. Teste casos limites
- Lista vazia: `[]`
- Um elemento: `[5]`
- Dois elementos: `[1, 2]`
- Todos iguais: `[3, 3, 3, 3]`
- Target no início/fim

---

## 📚 Recursos Adicionais

- Execute os testes: `dotnet test`
- Veja exemplos práticos: Execute o console app e teste cada exercício
- Leia `TESTS.md` para entender a estratégia de testes

---

**Boa sorte nos estudos!** 🚀
