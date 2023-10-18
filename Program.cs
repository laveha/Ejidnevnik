using System;

class Program
{
    static string[] zametki = new string[30];
    static string[] opisanie = new string[30];
    static DateTime currentDate = new DateTime(2023, 11, 1);
    static int viborzametkipos = 0;
    static int position = 0;
    static bool viewzametk = false;

    static void Main(string[] args)
    {
        SvodkaZametok();
        Svodkaopisani();
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            if (viewzametk)
            {
                viborzametki();
                key = Console.ReadKey(true);
                viewzametk = false;
            }
            else
            {
                data();
                zamet();
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    viewzametk = true;
                }
                else
                {
                    HandleKeyPress(key);
                }
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    static void SvodkaZametok()
    {
        for (int i = 0; i < 30; i++)
        {
            zametki[i] = "";
        }

        zametki[1] = "Занятия вождением";
        zametki[1] += "\nСрок сдачи практической";
        zametki[1] += "\nВыучить теорию ПДД";
        zametki[1] += "\nКатка в доту";
        zametki[1] += "\nОплата телефона";

        zametki[4] = "Просто заметка";
        zametki[10] = "Проверка описания";
    }

    static void Svodkaopisani()
    {
        for (int i = 0; i < 30; i++)
        {
            opisanie[i] = "";
        }
        opisanie[1] = "Не успеваю нифига до 23:59";
        opisanie[10] = "тест";
        opisanie[4] = "Типа проверка";
    }

    static void data()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Дата: {0:D}", currentDate);
    }

    static void zamet()
    {
        Console.SetCursorPosition(0, 2);
        for (int i = 0; i < 5; i++)
        {
            int dayIndex = currentDate.Day - 1;
            string[] notes = zametki[dayIndex].Split('\n');
            string noteopis = (i < notes.Length) ? notes[i] : string.Empty;
            Console.WriteLine($"   {i + 1}. {noteopis}");
        }
        Console.SetCursorPosition(0, 2 + viborzametkipos);
        Console.Write("=>");
    }

    static void HandleUpDownArrow(int direction)
    {
        viborzametkipos = Math.Clamp(viborzametkipos + direction, 0, 4);
    }
    static void HandleKeyPress(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.UpArrow)
        {
            HandleUpDownArrow(-1);
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            HandleUpDownArrow(1);
        }
        else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
        {
            HandleLeftRightArrow(key.Key);
        }
    }

    static void HandleLeftRightArrow(ConsoleKey key)
    {
        if (key == ConsoleKey.LeftArrow)
        {
            currentDate = currentDate.AddDays(-1);
        }
        else if (key == ConsoleKey.RightArrow)
        {
            currentDate = currentDate.AddDays(1);
        }
    }
    static void viborzametki()
    {
        Console.Clear();
        int dayIndex = currentDate.Day - 1;
        string[] notes = zametki[dayIndex].Split('\n');
        if (viborzametkipos < notes.Length)
        {
            Console.WriteLine($"Заметка {viborzametkipos + 1} на {currentDate:D}");
            Console.WriteLine("===================================");
            if (!string.IsNullOrEmpty(opisanie[dayIndex]))
            {
                Console.WriteLine("\nОписание:");
                Console.WriteLine(opisanie[dayIndex]);
            }
        }
        Console.WriteLine("\nНажмите любую клавишу для возвращения в меню.");
    }
}