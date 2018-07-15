using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure_SWD
{
    public class Characters
    {
        public string Name;
        public int Health = 100;
        public List<Item> CharacterItems = new List<Item>();
        public Room Position;

        public Characters(string _name, Room _position)
        {
            Position = _position;
            Name = _name;
            Position.Entry(this);
        }
        public void Inventory()
        {
            Console.WriteLine("You have the following items in your shoulder bag:");
            for (int i = 0; i < CharacterItems.Count; i++)
            {
                Console.WriteLine("- " + CharacterItems[i].Name);
            }
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
        }
        public void Insert(Item item)
        {
            CharacterItems.Add(item);
        }
        public Item Delete(string item)
        {
            Item _drop = null;
            for (int i = 0; i < CharacterItems.Count; i++)
            {
                if (CharacterItems[i].Name == item)
                {
                    _drop = CharacterItems[i];
                    CharacterItems.Remove(CharacterItems[i]);
                }
            }
            return _drop;
        }

        public void Move(string input)
        {
            Room _newRoom;
            Room _oldRoom = Position;

            switch (input)
            {
                case "n":
                    _newRoom = Position.North;
                    break;
                case "e":
                    _newRoom = Position.East;
                    break;
                case "s":
                    _newRoom = Position.South;
                    break;
                case "w":
                    _newRoom = Position.West;
                    break;
                default:
                    Console.WriteLine("Invalid Command!");
                    _newRoom = Position;
                    break;
            }

            if (_newRoom == null)
            {
                Console.WriteLine(this.Name + " did not move!");
                Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
            }
            else
            {
                if (_newRoom != Position)
                {
                    Position = _newRoom;
                    _newRoom.Exit(this);
                    Console.WriteLine(this.Name + " walked from " + _oldRoom.Name + " to " + _newRoom.Name);
                    Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                    _newRoom.Entry(this);
                }
            }
        }
    }
}