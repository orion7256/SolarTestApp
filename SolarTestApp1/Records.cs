﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarTestApp1
{
    class Records
    {
        public static List<Task> Tasks;
        private static void Init()
        {
            Tasks = new List<Task>();
        }
        public static void View(bool wait_flag = true)
        {
            check(0);
            if (Tasks.Count > 0)
            {
                Task.ShowTop();
                for (int i = 0; i < Tasks.Count; i++)
                    Tasks[i].Show(i+1);
                if(wait_flag)
                    Console.ReadKey();
            }
        }
        public static void Add()
        {
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
            View(false);
            Console.WriteLine("Enter record number to remove:\n");
            int num;
            Int32.TryParse(Console.ReadLine(), out num);
            if (check(num))
            {
                num--;
                Tasks.RemoveAt(num);
                Console.WriteLine("Success");
            }
        }
        public static void Edit()
        {
            View(false);
            Console.WriteLine("Enter record number to edit:\n");
            int num;
            Int32.TryParse(Console.ReadLine(), out num);

            if (check(num))
            {
                num--;
                Console.WriteLine("Old description: " + Tasks[num].Description);
                Console.Write("Enter new description: ");
                string desc = "";
                desc = Console.ReadLine();
                if (desc != "")
                {
                    Tasks[num].Description = desc;
                    Console.WriteLine("Success");
                }
            }
        }
        public static void save_data(string file = "file.binf")
        {
            Data2 d2 = new Data2();
            SerializableObject obj = new SerializableObject();
            obj.Data2 = d2;
            MySerializer serializer = new MySerializer();
            serializer.SerializeObject(file, obj);
            Console.WriteLine("Data saved to file: " + file);
            Console.ReadKey();
        }
        public static void load_data(string file = "file.binf")
        {
            if (file == "")
                return;
            MySerializer serializer = new MySerializer();
            Data2 d2 = serializer.DeserializeObject(file).Data2;
            Tasks = new List<Task>(Tasks.Union(d2.tasks));
            //Tasks = d2.tasks;
            Task.lastid = Tasks[Tasks.Count - 1].Id;
            Console.WriteLine("Data loaded from file: " + file);
            Console.ReadKey();
        }
        private static bool check(int number_toCheck)
        {
            if (Tasks == null)
                Init();
            if (Tasks.Count == 0)
                return false;
            if (Tasks.Count < number_toCheck)
                return false;
            if (number_toCheck<=0)
                return false;
            return true;
        }
    }
}
