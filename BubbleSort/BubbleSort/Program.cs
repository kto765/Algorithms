using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество чисел: ");
        int n = int.Parse(Console.ReadLine());

        int[] array = new int[n];

        Console.Write("Введите числа массива через пробел: ");
        string[] input = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(input[i]);
        }

        BubbleSort(array);

        Console.WriteLine("Отсортированный массив:");
        PrintArray(array);
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Меняем элементы местами
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
