
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов массива:");
        int n = int.Parse(Console.ReadLine()); // Количество элементов

        int[] array = new int[n]; // Создание массива заданного размера

        // Запрашиваем ввод элементов массива
        Console.WriteLine("Введите элементы массива (через пробел):");
        string[] input = Console.ReadLine().Split(' '); // Разбитие строки на элементы 

        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(input[i]); // Преобразование строки в числа
        }

        Console.WriteLine("Исходный массив:");
        PrintArray(array); // Вывод исходного массива

        MergeSort(array); // Запуск сортировки

        Console.WriteLine("nОтсортированный массив:");
        PrintArray(array); // Вывод отсортированного массива
    }

    // Сортировка массива с использованием сортировки слиянием
    static void MergeSort(int[] array)
    {
        if (array.Length <= 1) // если массив пустой или содержит один элемент
            return;

        int mid = array.Length / 2; // середина массива

        // Деление массива на две половины
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];

        // Копируем данные в левую сторону
        Array.Copy(array, 0, left, 0, mid);
        // Копируем данные в правую сторону
        Array.Copy(array, mid, right, 0, array.Length - mid);

        // Рекурсивно сортируем обе стороны
        MergeSort(left);
        MergeSort(right);

        // Сливаем отсортированные стороны
        Merge(array, left, right);
    }

    // Слияние двух отсортированных массивов
    static void Merge(int[] array, int[] left, int[] right)
    {
        int i = 0; // Индекс для левой половины
        int j = 0; // Индекс для правой половины
        int k = 0; // Индекс для основного массива

        // Сравниваем элементы из левой и правой половин и заполняем основной массив
        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                array[k] = left[i]; // элемент из левой половины меньше или равен
                i++;
            }
            else
            {
                array[k] = right[j]; // элемент из правой половины меньше
                j++;
            }
            k++;
        }

        // Оставшиеся элементы из левой половины 
        while (i < left.Length)
        {
            array[k] = left[i];
            i++;
            k++;
        }

        // Оставшиеся элементы из правой половины 
        while (j < right.Length)
        {
            array[k] = right[j];
            j++;
            k++;
        }
    }

    // Метод для отображения элементов массива
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " "); // Выводим каждый элемент массива
        }
        Console.WriteLine(); // Переходим на новую строку после вывода массива
    }
}
