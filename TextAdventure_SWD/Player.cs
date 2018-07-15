using System;
using System.Collections.Generic;
using System.Data;

namespace TextAdventure_SWD
{
    public class Player : Characters
    {
        public Player(string _name, Room _position) : base(_name, _position)
        {
        }
        int PlayerRandomAttack()
        {
            Random _randomNumber = new Random();
            int _random = _randomNumber.Next(0, 10);
            return _random;
        }

        int EnemyRandomAttack()
        {
            Random _randomNumber = new Random();
            int _random = _randomNumber.Next(0, 100);
            return _random;
        }
        public void Attack()
        {
            Game game = new Game();
            int _reduce = PlayerRandomAttack();
            Health = Health - _reduce;
            int _myreduce = _reduce;

            Console.WriteLine("you lost " + _reduce + " health points");

            Enemy enemy = Position.GetEnemy();
            _reduce = EnemyRandomAttack();
            int _enemyReduce = _reduce;
            enemy.Health -= _reduce;

            Console.WriteLine(enemy.Name + " lost " + _reduce + " health points.");

            if (Health <= 0)
            {
                Console.WriteLine("You lost! Your Opponent has beaten you!");
                Console.WriteLine("Feel free to play again!");

                Environment.Exit(0);
            }
            if (enemy.Health <= 0)
            {
                Console.WriteLine("You won against " + enemy.Name + "! You can now take one Item of " + enemy.Name + ".");
                TakeEnemyItems();
            }
        }

        public Item TakeEnemyItems()
        {
            string _item = Console.ReadLine();
            Item _take = null;
            for (int i = 0; i < Position.GetEnemy().CharacterItems.Count; i++)
            {
                if (Position.GetEnemy().CharacterItems[i].Name == _item)
                {
                    _take = Position.GetEnemy().CharacterItems[i];
                    CharacterItems.Remove(Position.GetEnemy().CharacterItems[i]);
                    Insert(_take);
                    Position.GetEnemy().CharacterItems.Remove(CharacterItems[i]);

                    Console.WriteLine("You took " + _item + ".");
                }
            }
            return _take;
        }
    }
}