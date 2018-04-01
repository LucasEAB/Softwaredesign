using System;

namespace Aufgabe1._2
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };
        
        static int l = subjects.Length;
        static string w1;
        static string w2;
        static string w3;
        static void Main(string[] args)
        {
            //Ausgabe
            string[] verse = new string[l];
            for (int i = 0; i < l; i++)
            {
                GetVerse();
                verse[i] = w1 + " " + w2 + " " + w3;
            }
            for (int v = 0; v < l; v++)
            {
                Console.WriteLine(verse[v]);
            }
        }

        public static void GetVerse()
        {
            Random rnd = new Random();

            int s = rnd.Next(0, l); // Zahl Subjekt
            int v = rnd.Next(0, l); // Zahl verb 
            int o = rnd.Next(0, l); // Zahl Objekt

            while (subjects[s] == "benutzt")
            {
                s = rnd.Next(0, l);
            }
            while (verbs[v] == "benutzt")
            {
                v = rnd.Next(0, l);
            }
            while (objects[o] == "benutzt")
            {
                o = rnd.Next(0, l);
            }
            w1 = subjects[s];
            w2 = verbs[v];
            w3 = objects[o];

            subjects[s] = "benutzt";
            verbs[v] = "benutzt";
            objects[o] = "benutzt";
        }
    }
}