using System;
using System.Threading;

namespace SolarTestApp1
{
    class Interface
    {
        public string source = "";
        public Interface()
        {
            Console.Clear();
            Console.Title = "Tasklist Korotkov A.A.";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            /*
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1-Файлы / 2-SQL DB");
            string tmp_result = Console.ReadLine();
            if (tmp_result == "1")
                source = "file.bin";
            else
                if (tmp_result == "2")
                    source = "mydb @ localhost";
            else
                Environment.Exit(0);
                */
            main_menu();
        }
        private void main_menu()
        {
            int Item = 0;
            string[] mark = new string[7];
            for (int f = 0; f < 7; f++) mark[f] = "  ";//init

            while (true)
            {
                Console.Clear();
                mark[Item] = "[>";
                Console.WriteLine("+-+-----------------------------+");
                Console.WriteLine("| |            Меню             |");
                Console.WriteLine("+-+-----------------------------+");
                Console.WriteLine(mark[0] + "|  1-Просмотр записей         |");
                Console.WriteLine(mark[1] + "|  2-Добавление записи        |");
                Console.WriteLine(mark[2] + "|  3-Удаление записи          |");
                Console.WriteLine(mark[3] + "|  4-Редактирование записи    |");
                Console.WriteLine(mark[4] + "|  5-Сохранение в файл        |");
                Console.WriteLine(mark[5] + "|  6-Загрузка из файла        |");
                Console.WriteLine(mark[6] + "|  0-Выход (Esc)              |");
                Console.WriteLine("+-+-----------------------------+");

                ConsoleKeyInfo ReadKey = Console.ReadKey(true);
                switch (ReadKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            mark[Item] = "  ";
                            if (Item < 6) Item++;
                            else Item = 0;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            mark[Item] = "  ";
                            if (Item > 0) Item--;
                            else Item = 6;
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.WriteLine("Doing " + Item);
                            DoTask(Item);

                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.WriteLine("Выход");
                            Thread.Sleep(500);
                            Environment.Exit(0);
                            break;
                        }//esc
                    default: break;
                }
            }
        }
        public void DoTask(int task_num = -1)
        {
            if (task_num != -1)
                switch (task_num)
                {
                    case 0: Records.View(); break;
                    case 1: Records.Add(); break;
                    case 2: Records.Remove(); break;
                    case 3: Records.Edit(); break;
                    case 4: Records.save_data(); break;
                    case 5: Records.load_data(); break;
                    case 6: Environment.Exit(0); break;
                    default: break;
                }
        }
    }
}
