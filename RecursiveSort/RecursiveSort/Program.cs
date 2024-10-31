using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите числа для сортировки, разделенные пробелами:");
        string input = Console.ReadLine();

        // Преобразуем строку ввода в массив целых чисел
        string[] inputArray = input.Split(' ');
        int[] numbers = Array.ConvertAll(inputArray, int.Parse);

        // Выводим исходный массив
        Console.WriteLine("Исходный массив: " + string.Join(" ", numbers));

        // Сортируем массив
        QuickSort(numbers, 0, numbers.Length - 1);

        // Выводим отсортированный массив
        Console.WriteLine("Отсортированный массив: " + string.Join(" ", numbers));
    }

    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // Находим индекс разделителя
            int pivotIndex = Partition(array, low, high);

            // Рекурсивно сортируем элементы до и после разделителя
            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high]; // Берем последний элемент как опорный
        int i = low - 1; // Индекс меньшего элемента

        for (int j = low; j < high; j++)
        {
            // Если текущий элемент меньше или равен опорному
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j); // Меняем местами
            }
        }
        Swap(array, i + 1, high); // Ставим опорный элемент на его правильное место
        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
