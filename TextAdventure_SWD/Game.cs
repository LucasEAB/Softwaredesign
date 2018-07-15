using System;
using System.Data;
using System.Collections.Generic;

namespace TextAdventure_SWD
{
    public class Game
    {
        Player Player;
        Enemy Oliver;
        List<Room> Rooms = new List<Room>();

        public void BuildGame()
        {
            DataTable _data = GetTable();

            foreach (DataRow _row in _data.Rows)
            {
                string _name = _row["Name"].ToString();
                Rooms.Add(new Room() { Name = _name });
            }

            int ir = 0;
            foreach (DataRow _row in _data.Rows)
            {
                string _direction = "";
                string _nextroom = "";
                Room _neighbour;

                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            _direction = "North";
                            break;
                        case 1:
                            _direction = "East";
                            break;
                        case 2:
                            _direction = "South";
                            break;
                        case 3:
                            _direction = "West";
                            break;
                    }
                    _nextroom = _row[_direction].ToString();

                    if (_nextroom != "")
                    {
                        _neighbour = null;
                        for (int r = 0; r < Rooms.Count; r++)
                        {
                            if (Rooms[r].Name == _nextroom)
                            {
                                _neighbour = Rooms[r];
                            }
                        }

                        switch (_direction)
                        {
                            case "North":
                                Rooms[ir].North = _neighbour;
                                break;
                            case "East":
                                Rooms[ir].East = _neighbour;
                                break;
                            case "South":
                                Rooms[ir].South = _neighbour;
                                break;
                            case "West":
                                Rooms[ir].West = _neighbour;
                                break;
                        }
                    }
                }
                string _item1 = _row["Item1"].ToString();
                if (_item1 != "")
                {
                    Rooms[ir].RoomItems.Add(new Item { Name = _item1 });
                }
                string item2 = _row["Item2"].ToString();
                if (item2 != "")
                {
                    Rooms[ir].RoomItems.Add(new Item { Name = item2 });
                }
                ir++;
            }

            //player
            Player = new Player("You", Rooms[4]);
            Player.CharacterItems.Add(new Item { Name = "lost bet slip" });

            //enemy
            Oliver = new Enemy("Oliver Kahn", Rooms[RandomRoom()]);
            Oliver.CharacterItems.Add(new Item { Name = "Golden Ticket" });
        }

        int RandomRoom()
        {
            Random _randomNumber = new Random();
            int _random = _randomNumber.Next(0, Rooms.Count);
            return _random;
        }

        int RandomMove()
        {
            Random _randomNumber = new Random();
            int _random = _randomNumber.Next(0, 4);
            return _random;
        }

        static DataTable GetTable()
        {
            DataTable _table = new DataTable();

            _table.Columns.Add("Name", typeof(string));
            _table.Columns.Add("North", typeof(string));
            _table.Columns.Add("East", typeof(string));
            _table.Columns.Add("South", typeof(string));
            _table.Columns.Add("West", typeof(string));
            _table.Columns.Add("Item1", typeof(string));
            _table.Columns.Add("Item2", typeof(string));



            _table.Rows.Add("the Betting Office", "the palace", "", "the sidewalk", "the toilet", "chair", "menu");
            _table.Rows.Add("the toilet", "", "the Betting Office", "", "", "toilet paper", "a soap");
            _table.Rows.Add("the palace", "", "", "the pokerroom", "", "paintings of Mai Pei", "sensei hair care set");
            _table.Rows.Add("the Udo Snack", "", "", "", "the sidewalk", "burger", "napkins");
            _table.Rows.Add("the sidewalk", "the Betting Office", "the Udo Snack", "", "", "bet slip", "brick");
            _table.Rows.Add("the pokerroom", "the palace", "", "the Betting Office", "", "poker chips", "drink");

            return _table;
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

            Description(Player);

            string _input = "";
            while (_input != "q")
            {
                if (_input == "n" || _input == "e" || _input == "s" || _input == "w")
                {
                    int _x = RandomRoom();
                    switch (_x)
                    {
                        case 0:
                            Oliver.Move("n");
                            break;
                        case 1:
                            Oliver.Move("e");
                            break;
                        case 2:
                            Oliver.Move("s");
                            break;
                        case 3:
                            Oliver.Move("w");
                            break;
                    }
                }

                _input = Console.ReadLine();

                try
                {
                    if (_input != "q")
                    {
                        switch (_input)
                        {
                            case "q":
                            case "quit":
                                break;
                            case "l":
                            case "look":
                                Description(Player);
                                break;
                            case "i":
                            case "inventory":
                                Player.Inventory();
                                break;
                            case "c":
                            case "commands":
                                Commands();
                                break;
                            case "d":
                            case "drop":
                                Drop(Player);
                                break;
                            case "t":
                            case "take":
                                Take(Player);
                                break;
                            case "n":
                            case "north":
                                Player.Move(_input);
                                Description(Player);
                                break;
                            case "e":
                            case "east":
                                Player.Move(_input);
                                Description(Player);
                                break;
                            case "s":
                            case "south":
                                Player.Move(_input);
                                Description(Player);
                                break;
                            case "w":
                            case "west":
                                Player.Move(_input);
                                Description(Player);
                                break;
                            case "a":
                            case "attack":
                                Player.Attack();
                                Description(Player);
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
            Enemy _enemy = p.Position.GetEnemy();
            Console.WriteLine("Your current Location is " + p.Position.Name + ".");
            if (_enemy != null)
            {
                Console.WriteLine("In " + p.Position.Name + " you can see " + _enemy.Name + " with the Health of " + _enemy.Health + ". With a/attack you can try to beat him up! Maybe you get some informations.");
                Look(p);
            }
            p.Position.Look();
            Console.WriteLine("You have " + p.Health + " health points.");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));

        }

        void Take(Player p)
        {
            Console.WriteLine("Which Item would you like to take?");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
            string _item = Console.ReadLine();
            Item _takeItem = p.Position.Take(_item);
            p.Insert(_takeItem);
        }

        void Drop(Player p)
        {
            Console.WriteLine("Which Item would you like to drop?");
            p.Inventory();
            string _item = Console.ReadLine();

            Item _dropItem = p.Delete(_item);
            p.Position.Drop(_dropItem);
        }

        void Commands()
        {
            Console.WriteLine("Choose between the following commands: commands(c), look(l), inventory(i), take(t) item, drop(d) item, quit(q).");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth - Console.CursorLeft, '─'));
        }

        void Look(Player p)
        {
            Console.WriteLine("You see " + p.Position.GetEnemy().Name + ". His Items are: ");
            for (int i = 0; i < p.Position.GetEnemy().CharacterItems.Count; i++)
            {
                Console.WriteLine("- " + p.Position.GetEnemy().CharacterItems[i].Name);
            }
        }
    }
}