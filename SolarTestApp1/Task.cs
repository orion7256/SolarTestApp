﻿using System;

namespace SolarTestApp1
{
    [Serializable]
    public class Task
    {
        public static int lastid = 0;
        private int id;
        private string description;
        private DateTime date;
        public int Id { get {return id;} }
        public string Description { get { return description; } set {description = value;} }
        public DateTime Date { get { return date;} }
        public Task (string desc = "")
        {
            description = desc;
            id = lastid + 1;
            lastid++;
            date = DateTime.Now;
        }
        public static void ShowTop()
        {
            string ret = "";
            ret += "Num|ID   |Date             |Description\n";
            ret += "=======================================\n";
            Console.WriteLine(ret);
        }
        public void Show(int num = 0)
        {
            string ret = "";
            if (num < 10)
                ret += num + "  |";
            else
                ret += num + " |";
            if (Id < 10)
                ret+= Id + "    |";
            else
                ret += Id + "   |";
            ret += Date.ToShortDateString() + " " + Date.ToShortTimeString() + " |";
            ret += Description;
            Console.WriteLine(ret);
        }
    }
}
