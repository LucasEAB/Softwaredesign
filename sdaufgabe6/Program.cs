﻿using System;
using System.Collections.Generic;

namespace sdaufgabe6Singleton
{
    public class Person
    {
        public Person(String Name, int Age)
        {

            this.Name = Name;
            this.Age = Age;
            this.Id = IDGenerator.GetInstance().GibMirNeId();

            Program.personen.Add(this);
        }

        public string Name;
        public int Age;
        private int Id;

        public override string ToString()
        {
            return "Name:" + Name + ", Age: " + Age + ", " + "Id: " + Id;
        }
    }

    public class IDGenerator
    {
        private IDGenerator()
        {
            letzteID = 1;
        }

        private static IDGenerator _instance;

        public static IDGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new IDGenerator();
            return _instance;
        }

        private int letzteID;
        public int GibMirNeId()
        {
            return letzteID++;
        }
    }

    class Program
    {
        public static List<Person> personen = new List<Person>();

        public static void Main(string[] args)
        {
            // Eine Stelle, an der Personen angelegt werden
            new Person("Horst", 4);
            new Person("Horst", 45);
            new Person("Walter", 33);
            new Person("Karl-Heinz", 22);

            // Eine ANDERE Stelle, an der Personen angelegt werden
            new Person("Brunhilde", 56);
            new Person("Maria", 75);
            new Person("Kunigunde", 22);
            new Person("Tusnelda", 12);

            foreach (var person in personen)
                Console.WriteLine(person);

            Console.WriteLine("Hello World!");
        }
    }
}