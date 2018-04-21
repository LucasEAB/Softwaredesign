using System;

namespace Aufgabe1._2
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        
        static int length = subjects.Length;
        static string word1;
        static string word2;
        static string word3;
        static void Main(string[] args)
        {
            string[] verse = new string[length];
            for (int i = 0; i < length; i++)
            {
                GetVerse();
                verse[i] = word1 + " " + word2 + " " + word3;
            }
            for (int v = 0; v < length; v++)
            {
                Console.WriteLine(verse[v]);
            }
        }

        public static void GetVerse()
        {
            Random rnd = new Random();

            int s = rnd.Next(0, length); // Zahl Subjekt
            int v = rnd.Next(0, length); // Zahl verb 
            int o = rnd.Next(0, length); // Zahl Objekt

            while (subjects[s] == "used")
            {
                s = rnd.Next(0, length);
            }
            while (verbs[v] == "used")
            {
                v = rnd.Next(0, length);
            }
            while (objects[o] == "used")
            {
                o = rnd.Next(0, length);
            }
            word1 = subjects[s];
            word2 = verbs[v];
            word3 = objects[o];

            subjects[s] = "used";
            verbs[v] = "used";
            objects[o] = "used";
        }
    }
}