using System;

class Program
{
    static void Main()
    {
        // Запрос количества чисел в массиве
        Console.Write("Введите количество чисел: ");
        int n = int.Parse(Console.ReadLine());

        // Создание массива чисел 
        int[] array = new int[n];

        // Запрос числа массива через пробел
        Console.Write("Введите числа массива через пробел: ");
        string[] input = Console.ReadLine().Split(' ');

        // Заполнение массива числами, которые были введены
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(input[i]);
        }

        // Функция сортировки пузырьком
        BubbleSort(array);

        // Вывод отсортированного массива
        Console.WriteLine("Отсортированный массив:");
        PrintArray(array);
    }

    // Функция сортировки пузырьком
    static void BubbleSort(int[] arr)
    {
        // n - количество элементов в массиве
        int n = arr.Length;

        // Внешний цикл проходит по массиву n-1 раз
        for (int i = 0; i < n - 1; i++)
        {
            // Отслеживание, произошла ли замена элементов
            bool swapped = false;

            // Внутренний цикл проходит по массиву (n-i-1) раз
            for (int j = 0; j < n - i - 1; j++)
            {
                // Если текущий элемент больше следующего, то меняем их местами
                if (arr[j] > arr[j + 1])
                {
                    // Сохранение значения текущего элемента
                    int temp = arr[j];
                    // Присвоение текущему элементу значение следующего
                    arr[j] = arr[j + 1];
                    // Присвоение следующему элементу сохраненное значение
                    arr[j + 1] = temp;
                    // Замена произошла
                    swapped = true;
                }
            }

            // Если замены не было, значит массив уже отсортирован
            if (!swapped)
                break;
        }
    }

    // Функция для вывода массива на консоль
    static void PrintArray(int[] arr)
    {
        // Проходим по всем элементам массива и выводим их на консоль
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        // Переходим на новую строку
        Console.WriteLine();
    }
}

