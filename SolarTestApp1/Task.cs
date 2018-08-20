using System;

namespace SolarTestApp1
{
    class Task
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
            ret += "ID   |Date             |Description\n";
            ret += "===================================\n";
            Console.WriteLine(ret);
        }
        public void Show()
        {
            string ret = "";
            if (Id < 10)
                ret+= Id + "    |";
            else
                ret += Id + "   |";
            ret += Date.ToShortDateString() + " " + Date.ToShortTimeString() + " |";
            ret += Description;
            //ret += "\n";
            Console.WriteLine(ret);
        }
    }
}
