using System;

public class MedianFinder
{
    private int[] data;  // Массив для хранения чисел
    private int count = 0; // Количество элементов
    private int capacity = 10; // Начальная емкость массива

    public MedianFinder() { data = new int[capacity]; }

    // Добавление числа
    public void AddNum(int num)
    {
        // Увеличение размера массива, если он полный
        if (count == capacity) Resize();
        data[count++] = num;
    }

    // Нахождение медианы
    public double FindMedian()
    {
        if (count == 0) return 0; // Пустой массив

        // Сортировка массива 
        Array.Sort(data, 0, count);

        int mid = count / 2; // Если четное количество элементов, то находим среднее двух чисел
        return count % 2 == 0 ? (data[mid - 1] + data[mid]) / 2.0 : data[mid]; // Если нечетное, возвращаем средний элемент
    }

    // Увеличение размера массива в 2 раза
    private void Resize()
    {
        capacity *= 2;
        Array.Resize(ref data, capacity);
    }

    public static void Main(string[] args)
    {
        MedianFinder mf = new MedianFinder();
        Console.WriteLine("Введите числа с пробелами (или 'exit' для завершения):");
        string line;
        while ((line = Console.ReadLine()) != "exit")
        {
            try
            {
                string[] nums = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string numStr in nums)
                {
                    mf.AddNum(int.Parse(numStr));
                    Console.WriteLine($"Текущая медиана: {mf.FindMedian()}");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода.");
            }
        }
    }
}
