using System;
using System.Collections.Generic;

namespace SolarTestApp1
{
    class Records
    {
        public static List<Task> Tasks;
        private static void Init()
        {
            Tasks = new List<Task>();
        }
        public static void View()
        {
            if (Tasks == null)
                return;
            if (Tasks.Count>0)
            {
                Task.ShowTop();
                for (int i = 0; i < Tasks.Count; i++)
                    Tasks[i].Show();
                Console.ReadKey();
            }
        }
        public static void Add()
        {
            if (Tasks == null)
                Init();
            Console.WriteLine("Record adding: " + DateTime.Today.ToShortDateString() + "\n");
            string desc = Console.ReadLine();
            if (desc != "")
            {
                Tasks.Add(new Task(desc));
                Console.WriteLine("Success");
            }
        }
        public static void Remove()
        {
            if (Tasks == null)
                return;
            View();
            Console.WriteLine("Enter record number to remove:\n");
            int num = -1;
            Int32.TryParse(Console.ReadLine(), out num);
            if ((num != -1) || (num < Tasks.Count))
            {
                Tasks.RemoveAt(--num);
                Console.WriteLine("Success");
            }
        }
        public static void Edit()
        {
            if (Tasks == null)
                return;
            View();
            Console.WriteLine("Enter record number to edit:\n");
            int num;
            Int32.TryParse(Console.ReadLine(), out num);
            if ((num != -1) || (num < Tasks.Count))
            {
                Console.WriteLine("Old description: " + Tasks[--num].Description);
                Console.Write("Enter new description: ");
                string desc = "";
                desc = Console.ReadLine();
                if (desc != "")
                {
                    Tasks[--num].Description = desc;
                    Console.WriteLine("Success");
                }
                
            }
        }
    }
}
