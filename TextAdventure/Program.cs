using System;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rooms
            Room bettingoffice = new Room();
            Room toilet = new Room();
            Room palace = new Room();
            Room udosnack = new Room();
            Room sidewalk = new Room();
            Room pokerroom = new Room();

            //directions
            bettingoffice.west = toilet;
            bettingoffice.north = pokerroom;
            bettingoffice.south = sidewalk;
            toilet.east = bettingoffice;
            palace.south = pokerroom;
            udosnack.south = sidewalk;
            sidewalk.north = bettingoffice;
            sidewalk.east = udosnack;
            pokerroom.north = palace;
            pokerroom.south = bettingoffice;

            //characters
            Character player = new Character();

            //commands
            string input = "";
            while (input != "q")
            {
                show(player);
                input = Console.ReadLine();

                try
                {
                    if (input != "q")
                    {
                        switch (input)
                        {
                            case "q":
                                break;
                            case "n":
                                player.position = player.position.gonorth();
                                break;
                            case "e":
                                player.position = player.position.goeast();
                                break;
                            case "s":
                                player.position = player.position.gosouth();
                                break;
                            case "w":
                                player.position = player.position.gowest();
                                break;
                            default:
                                Console.WriteLine("Go to an other direction.");
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter n, s, w or e ");
                }
            }
        }
    }
    class Room
    {
        public Room north;
        public Room south;
        public Room west;
        public Room east;

        public Room gonorth()
        {
            if (north == null)
            {
                Console.WriteLine("invalid way!");
                return this;
            }
            return north;
        }
        public Room goeast()
        {
            if (east == null)
            {
                Console.WriteLine("invalid way!");
                return this;
            }
            return east;
        }
        public Room gowest()
        {
            if (west == null)
            {
                Console.WriteLine("invalid way!");
                return this;
            }
            return west;
        }
        public Room gosouth()
        {
            if (south == null)
            {
                Console.WriteLine("invalid way!");
                return this;
            }
            return south;
        }

    }

    class Character
    {
        public Character position;
    }
}
