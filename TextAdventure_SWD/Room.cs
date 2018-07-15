using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure_SWD
{
    public class Room
    {
        public List<Item> RoomItems = new List<Item>();
        public List<Characters> RoomPlayers = new List<Characters>();

        public string Name;
        public Room North;
        public Room East;
        public Room South;
        public Room West;

        public void Exit(Characters player)
        {
            RoomPlayers.Remove(player);
        }

        public void Entry(Characters player)
        {
            RoomPlayers.Add(player);
        }

        public Enemy GetEnemy()
        {
            for (int i = 0; i < RoomPlayers.Count; i++)
            {
                if (RoomPlayers[i].GetType() == typeof(Enemy))
                {
                    if (RoomPlayers[i].Health > 0)
                    {
                        return (Enemy)RoomPlayers[i];
                    }
                }
            }
            return null;
        }

        public Item Take(string item)
        {
            Item _take = null;
            for (int i = 0; i < RoomItems.Count; i++)
            {
                if (RoomItems[i].Name == item)
                {
                    _take = RoomItems[i];
                    RoomItems.Remove(RoomItems[i]);
                    Console.WriteLine("You took " + item + ".");
                    Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                }
            }
            return _take;
        }

        public void Drop(Item item)
        {
            RoomItems.Add(item);
            Console.WriteLine("You dropped " + item + ".");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
        }

        public void Look()
        {
            Console.WriteLine("You can see:");
            for (int i = 0; i < RoomItems.Count; i++)
            {
                Console.WriteLine("- " + RoomItems[i].Name);
            }
        }
    }
}
