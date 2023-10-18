using System;
using System.Collections.Generic;

namespace Ntc
{
    //Это класс, возможно школьный
    class shutki_v_storonu
    {
        static List<classroom> ntcs = new List<classroom>();
        static int inpt = 0;

        static void Main(string[] args)
        {
            //Создание заметок
            ntcs.Add(new classroom("Проснуться (опционально)", "Поесть (Обязательно)", new DateTime(2023, 1, 6), new DateTime(2023, 1, 9, 17, 0, 0)));
            ntcs.Add(new classroom("Заболеть (желательно)", "Написать 3-й практос по С# (невозможно)", new DateTime(2023, 1, 8), new DateTime(2023, 1, 8, 11, 47, 0)));
            ntcs.Add(new classroom("заработать больше седых волос (неизбежно)", "хз, не придумал", new DateTime(2023, 1, 13), new DateTime(2023, 1, 21, 19, 0, 0)));

            Console.WriteLine("Ежедневник");
            Console.WriteLine();

            while (true)
            {
                menu();

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    Swtchdt(-1);
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    Swtchdt(1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Opnnt();
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
            }
        }

        //меню, возможно ресторанное
        static void menu()
        {
            classroom note = ntcs[inpt];

            Console.WriteLine("Дата: " + note.dt.ToString("dd.MM.yyyy"));
            Console.WriteLine();
            Console.WriteLine("Заметка: " + note.ttle);
            Console.WriteLine();
            Console.WriteLine("Для переключения между датами используйте стрелки вправо, влево");
            Console.WriteLine("Хотите открыть полную информацию? Используйте клавишу Enter");
            Console.WriteLine("Чтобы выйти из программы используйте клавишу Esc");
        }

        static void Swtchdt(int peremennaya)
        {
            inpt += peremennaya;

            if (inpt < 0)
            {
                inpt = ntcs.Count - 1;
            }
            else if (inpt >= ntcs.Count)
            {
                inpt = 0;
            }
        }
        static void Opnnt()
        {
            classroom note = ntcs[inpt];
            Console.Clear();
            Console.WriteLine("Заметка: " + note.ttle);
            Console.WriteLine();
            Console.WriteLine("Описание: " + note.desc);
            Console.WriteLine();
            Console.WriteLine("Дата: " + note.dt.ToString("dd.MM.yyyy"));
            Console.WriteLine("Время выполнения: " + note.extm.ToString("HH:mm:ss"));
            Console.WriteLine();
            Console.WriteLine("Чтобы выйти в меню нажмити любую клавишу");
            Console.ReadKey();
        }
    }

    class classroom
    {
        public string ttle { get; set; }
        public string desc { get; set; }
        public DateTime dt { get; set; }
        public DateTime extm { get; set; }

        public classroom(string title, string description, DateTime date, DateTime executionTime)
        {
            ttle = title;
            desc = description;
            dt = date;
            extm = executionTime;
        }
    }
}