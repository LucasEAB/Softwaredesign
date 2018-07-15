using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure_SWD
{
    public class Characters
    {
        public string name;
        public int health = 100;
        public List<Item> CharacterItems = new List<Item>();
        public Room position;

        public Characters(string _name, Room _position)
        {
            position = _position;
            name = _name;
            position.Entry(this);
        }
        public void Inventory()
        {
            Console.WriteLine("You have the following items in your shoulder bag:");
            for (int i = 0; i < CharacterItems.Count; i++)
            {
                Console.WriteLine("- " + CharacterItems[i].name);
            }
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
        }
        public void Insert(Item item)
        {
            CharacterItems.Add(item);
        }
        public Item Delete(string item)
        {
            Item drop = null;
            for (int i = 0; i < CharacterItems.Count; i++)
            {
                if (CharacterItems[i].name == item)
                {
                    drop = CharacterItems[i];
                    CharacterItems.Remove(CharacterItems[i]);
                }
            }
            return drop;
        }

        public void Move(string input)
        {
            Room newRoom;
            Room oldRoom = position;

            switch (input)
            {
                case "n":
                    newRoom = position.north;
                    break;
                case "e":
                    newRoom = position.east;
                    break;
                case "s":
                    newRoom = position.south;
                    break;
                case "w":
                    newRoom = position.west;
                    break;
                default:
                    Console.WriteLine("Invalid Command!");
                    newRoom = position;
                    break;
            }

            if (newRoom == null)
            {
                Console.WriteLine(this.name + " did not move!");
                Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
            }
            else
            {
                if (newRoom != position)
                {
                    position = newRoom;
                    oldRoom.Exit(this);
                    Console.WriteLine(this.name + " walked from " + oldRoom.name + " to " + newRoom.name);
                    Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                    newRoom.Entry(this);
                }
            }
        }
    }
}