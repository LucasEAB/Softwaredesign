using System;
using System.Data;
using System.Collections.Generic;

namespace TextAdventure_SWD
{
    public class Game
    {
        Player player;
        Enemy oliver;
        List<Room> Rooms = new List<Room>();

        public void BuildGame()
        {
            DataTable data = GetTable();

            foreach (DataRow row in data.Rows)
            {
                string _name = row["Name"].ToString();
                Rooms.Add(new Room() { name = _name });
            }

            int ir = 0;
            foreach (DataRow row in data.Rows)
            {
                string direction = "";
                string nextroom = "";
                Room neighbour;

                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            direction = "North";
                            break;
                        case 1:
                            direction = "East";
                            break;
                        case 2:
                            direction = "South";
                            break;
                        case 3:
                            direction = "West";
                            break;
                    }
                    nextroom = row[direction].ToString();

                    if (nextroom != "")
                    {
                        neighbour = null;
                        for (int r = 0; r < Rooms.Count; r++)
                        {
                            if (Rooms[r].name == nextroom)
                            {
                                neighbour = Rooms[r];
                            }
                        }

                        switch (direction)
                        {
                            case "North":
                                Rooms[ir].north = neighbour;
                                break;
                            case "East":
                                Rooms[ir].east = neighbour;
                                break;
                            case "South":
                                Rooms[ir].south = neighbour;
                                break;
                            case "West":
                                Rooms[ir].west = neighbour;
                                break;
                        }
                    }
                }
                ir++;
            }

            //Room Items
            Rooms[0].RoomItems.Add(new Item { name = "chair" });
            Rooms[0].RoomItems.Add(new Item { name = "drink" });
            Rooms[0].RoomItems.Add(new Item { name = "menu" });

            Rooms[1].RoomItems.Add(new Item { name = "toilet paper" });
            Rooms[1].RoomItems.Add(new Item { name = "a soap" });
            Rooms[1].RoomItems.Add(new Item { name = "a strange note" });

            Rooms[2].RoomItems.Add(new Item { name = "golden statue" });
            Rooms[2].RoomItems.Add(new Item { name = "paintings of Mai Pei" });
            Rooms[2].RoomItems.Add(new Item { name = "sensei hair care set" });

            Rooms[3].RoomItems.Add(new Item { name = "burger" });
            Rooms[3].RoomItems.Add(new Item { name = "currywurst" });
            Rooms[3].RoomItems.Add(new Item { name = "napkins" });

            Rooms[4].RoomItems.Add(new Item { name = "piece of trash" });
            Rooms[4].RoomItems.Add(new Item { name = "bet slip" });
            Rooms[4].RoomItems.Add(new Item { name = "brick" });

            Rooms[5].RoomItems.Add(new Item { name = "poker chips" });
            Rooms[5].RoomItems.Add(new Item { name = "drink" });
            Rooms[5].RoomItems.Add(new Item { name = "cards" });

            //player
            player = new Player("You", Rooms[4]);
            player.CharacterItems.Add(new Item { name = "lost bet slip" });

            //enemy
            oliver = new Enemy("Oliver Kahn", Rooms[RandomRoom()]);
            oliver.CharacterItems.Add(new Item { name = "Golden Tipico bet slip" });
            oliver.position = Rooms[1];
        }

        int RandomRoom()
        {
            Random randomNumber = new Random();
            int random = randomNumber.Next(0, Rooms.Count);
            return random;
        }

        int RandomMove()
        {
            Random randomNumber = new Random();
            int random = randomNumber.Next(0, 4);
            return random;
        }

        static DataTable GetTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("North", typeof(string));
            table.Columns.Add("East", typeof(string));
            table.Columns.Add("South", typeof(string));
            table.Columns.Add("West", typeof(string));

            table.Rows.Add("the Betting Office", "the palace", "", "the sidewalk", "the toilet");
            table.Rows.Add("the toilet", "", "the Betting Office", "", "");
            table.Rows.Add("the palace", "", "", "the pokerroom", "");
            table.Rows.Add("the Udo Snack", "", "", "", "the sidewalk");
            table.Rows.Add("the sidewalk", "the Betting Office", "the Udo Snack", "", "");
            table.Rows.Add("the pokerroom", "the palace", "", "the Betting Office", "");

            return table;
        }

        public void Play()
        {
            //Intro
            Console.WriteLine("Welcome to Gambling Addiction!");
            Console.WriteLine("In this little Text Adventure you play a character who is tired of losing in gambling!");
            Console.WriteLine("He would do anything to win again!");
            Console.WriteLine("He is on his way to his local Betting Office like always...");
            Console.WriteLine("");
            Console.WriteLine("You control with the help of the following inputs: north(n), east(e), south(s), west(w), commands(c), look(l), inventory(i), attack(a), take(t), drop(d), quit(q)");
            Console.WriteLine("If you ever forgot the appropriate command just type commands or c.");
            Console.WriteLine("Now let the Gambling start :)");
            Console.WriteLine("");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));

            Description(player);

            string input = "";
            while (input != "q")
            {
                if (input == "n" || input == "e" || input == "s" || input == "w")
                {
                    int x = RandomRoom();
                    switch (x)
                    {
                        case 0:
                            oliver.Move("n");
                            break;
                        case 1:
                            oliver.Move("e");
                            break;
                        case 2:
                            oliver.Move("s");
                            break;
                        case 3:
                            oliver.Move("w");
                            break;
                    }
                }

                input = Console.ReadLine();

                try
                {
                    if (input != "q")
                    {
                        switch (input)
                        {
                            case "q":
                            case "quit":
                                break;
                            case "l":
                            case "look":
                                Description(player);
                                break;
                            case "i":
                            case "inventory":
                                player.Inventory();
                                break;
                            case "c":
                            case "commands":
                                Commands();
                                break;
                            case "d":
                            case "drop":
                                Drop(player);
                                break;
                            case "t":
                            case "take":
                                Take(player);
                                break;
                            case "n":
                            case "north":
                                player.Move(input);
                                Description(player);
                                break;
                            case "e":
                            case "east":
                                player.Move(input);
                                Description(player);
                                break;
                            case "s":
                            case "south":
                                player.Move(input);
                                Description(player);
                                break;
                            case "w":
                            case "west":
                                player.Move(input);
                                Description(player);
                                break;
                            case "a":
                            case "attack":
                                player.Attack();
                                Description(player);
                                break;
                            default:
                                Console.WriteLine("Invalid Command!");
                                Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Command!");
                    Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
                }
            }
        }

        void Description(Player p)
        {
            Enemy _enemy = p.position.GetEnemy();
            Console.WriteLine("Your current Location is " + p.position.name + ".");
            if (_enemy != null)
            {
                Console.WriteLine("In " + p.position.name + " you can see " + _enemy.name + " with the Health of " + _enemy.health + ". With a/attack you can try to beat him up! Maybe you get some informations.");
            }

            p.position.Look();
            Console.WriteLine("You have " + p.health + " health points.");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));

        }

        void Take(Player player)
        {
            Console.WriteLine("Which Item would you like to take?");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
            string item = Console.ReadLine();
            Item takeItem = player.position.Take(item);
            player.Insert(takeItem);
        }

        void Drop(Player player)
        {
            Console.WriteLine("Which Item would you like to drop?");
            player.Inventory();
            string item = Console.ReadLine();

            Item dropItem = player.Delete(item);
            player.position.Drop(dropItem);
        }

        void Commands()
        {
            Console.WriteLine("Choose between the following commands: commands(c), look(l), inventory(i), take(t) item, drop(d) item, quit(q).");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
        }
    }
}