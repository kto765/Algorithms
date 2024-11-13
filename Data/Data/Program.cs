public class Program
{
    public static void Main()
    {
        // Входные данные
        string[] startTimes = { "10:00", "11:00", "15:00", "15:30", "16:50" };
        int[] durations = { 60, 30, 10, 10, 40 };
        string beginWorkingTime = "08:00";
        string endWorkingTime = "18:00";
        int consultationTime = 30;

        // Вызов функции для поиска свободных промежутков
        List<string> freeSlots = FindFreeTimeSlots(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

        // Вывод свободных временных промежутков
        Console.WriteLine("Свободные временные промежутки:");
        foreach (string slot in freeSlots)
        {
            Console.WriteLine(slot);
        }
    }

    public static List<string> FindFreeTimeSlots(string[] startTimes, int[] durations, string beginWorkingTime, string endWorkingTime, int consultationTime)
    {
        TimeSpan workStart = TimeSpan.Parse(beginWorkingTime);
        TimeSpan workEnd = TimeSpan.Parse(endWorkingTime);
        TimeSpan consultationDuration = TimeSpan.FromMinutes(consultationTime);

        List<string> freeSlots = new List<string>();
        TimeSpan current = workStart;

        // Основной цикл для проверки каждого занятого промежутка
        for (int i = 0; i < startTimes.Length; i++)
        {
            TimeSpan start = TimeSpan.Parse(startTimes[i]);
            TimeSpan end = start.Add(TimeSpan.FromMinutes(durations[i]));

            // Поиск свободных промежутков перед текущим занятим
            while (current.Add(consultationDuration) <= start)
            {
                freeSlots.Add($"{current:hh:mm}-{current.Add(consultationDuration):hh:mm}");
                current = current.Add(consultationDuration);
            }

            // Обновление текущего времени до конца текущего занятого промежутка
            current = end > current ? end : current;
        }

        // Проверка на оставшийся свободный промежуток 
        while (current.Add(consultationDuration) <= workEnd)
        {
            freeSlots.Add($"{current:hh:mm}-{current.Add(consultationDuration):hh:mm}");
            current = current.Add(consultationDuration);
        }

        return freeSlots;
    }
}
