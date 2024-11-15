using System;

class Program
{
    static void Main()
    {
        // Время начала графика сотрудника
        string[] startTimes = { "10:00", "11:00", "15:00", "15:30", "16:50" };
        // Продолжительность в минутах
        int[] durations = { 60, 30, 10, 10, 40 };
        // Минимальное необходимое время для работы менеджера
        int consultationTime = 30;
        // Начало рабочего дня
        string beginWorkingTime = "08:00";
        // Конец рабочего дня
        string endWorkingTime = "18:00";

        // Вывод свободных временных промежутков
        string[] freeIntervals = GetFreeTimeIntervals(startTimes, durations, consultationTime, beginWorkingTime, endWorkingTime);

        // Вывод найденных свободных временных промежутков
        foreach (var interval in freeIntervals)
        {
            Console.WriteLine(interval);
        }
    }

    static string[] GetFreeTimeIntervals(string[] startTimes, int[] durations, int consultationTime, string beginWorkingTime, string endWorkingTime)
    {
        // Преобразование начала и конца рабочего дня в минуты
        int beginWorkingMinutes = TimeToMinutes(beginWorkingTime);
        int endWorkingMinutes = TimeToMinutes(endWorkingTime);

        // Создание массива для хранения свободных временных интервалов, максимум 100 
        string[] freeIntervals = new string[100];
        int freeIndex = 0; 

        // Начало рабочего дня
        int currentStart = beginWorkingMinutes;

        for (int i = 0; i < startTimes.Length; i++)
        {
            // Преобразование времени начала в минуты
            int start = TimeToMinutes(startTimes[i]);
            // Получение продолжительность
            int duration = durations[i];
            // Вычисление времени окончания
            int end = start + duration;

            // Проверка на то, есть ли свободное время перед текущим занятым временем
            if (currentStart + consultationTime <= start)
            {
                int freeEnd = start; // Конец свободного времени

                // Заполнение массива свободными интервалами до начала 
                while (currentStart + consultationTime <= freeEnd)
                {
                    freeIntervals[freeIndex++] = MinutesToTime(currentStart) + "-" + MinutesToTime(currentStart + consultationTime);
                    currentStart += 30; // Увеличение текущего времени на 30 минут для поиска следующих интервалов
                }
            }

            // Обновление текущего времени до конца занятого интервала
            currentStart = Math.Max(currentStart, end);
        }

        // Добавление свободных интервалов после последнего занятого времени до конца рабочего дня
        if (currentStart + consultationTime <= endWorkingMinutes)
        {
            while (currentStart + consultationTime <= endWorkingMinutes)
            {
                freeIntervals[freeIndex++] = MinutesToTime(currentStart) + "-" + MinutesToTime(currentStart + consultationTime);
                currentStart += 30; // Увеличение текущего времени на 30 минут для поиска следующих интервалов
            }
        }

        // Количество найденных интервалов
        string[] result = new string[freeIndex];
        Array.Copy(freeIntervals, result, freeIndex);

        return result; // Возвращение массива свободных временных интервалов
    }

    // Метод для преобразования времени в минуты
    static int TimeToMinutes(string time)
    {
        var parts = time.Split(':');
        return int.Parse(parts[0]) * 60 + int.Parse(parts[1]);
    }

    // Метод для преобразования минут обратно 
    static string MinutesToTime(int minutes)
    {
        int hours = minutes / 60;
        int mins = minutes % 60;
        return $"{hours:D2}:{mins:D2}";
    }
}
