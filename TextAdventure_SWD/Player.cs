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
        
        public void Attack()
        {
            Random random = new Random();
            int randomNumberPlayerHealth = random.Next(0, 100);
            int randomNumberEnemyHealth = random.Next(0, 100);
            health = health - randomNumberPlayerHealth;
            position.GetEnemy().health -= randomNumberEnemyHealth;

            if (health <= 0)
            {
                Console.WriteLine("You lost! Your Opponent has beaten you!");
                Console.WriteLine("Feel free to play again!");

                Environment.Exit(0);
            }
            if (position.GetEnemy().health <= 0)
            {
                Console.WriteLine("You Won against your opponent!");
                
            }
        }
    }
}