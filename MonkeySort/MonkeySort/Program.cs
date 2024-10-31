using System;

public class MonkeySort
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите числа с пробелами:");
        string input = Console.ReadLine();

        // Разбиваем строку на массив строк
        string[] numbersStr = input.Split(' ');

        // Преобразуем массив строк в массив целых чисел
        int[] numbers = new int[numbersStr.Length];
        for (int i = 0; i < numbersStr.Length; i++)
        {
            numbers[i] = int.Parse(numbersStr[i]);
        }

        // Сортировка обезьянкой
        MonkeySortArray(numbers);

        // Вывод отсортированного массива
        Console.WriteLine("Отсортированный массив:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    // Функция сортировки обезьянкой
    private static void MonkeySortArray(int[] array)
    {
        Random random = new Random();
        int n = array.Length;

        // Проводим сортировку до тех пор, пока массив не будет отсортирован
        while (!IsSorted(array))
        {
            // Случайно выбираем два индекса
            int i = random.Next(n);
            int j = random.Next(n);

            // Меняем местами элементы
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    // Проверка, отсортирован ли массив
    private static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false; // Массив не отсортирован
            }
        }
        return true; // Массив отсортирован
    }
}


