using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimulation
{
    struct Monster
    {
        public string name;
        public float health;
        public float damage;
        public float defense;

        //constructor
        public Monster(string name,
            float health, 
            float damage,
            float defense)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.defense = defense;
        }
    }
    internal class Game
    {
        bool _gameOver = false;

        Monster _monster1;

        Monster _monster2;

        Monster _monster3;
        void Start()
        {
            //creatura 1
            _monster1 = new Monster("Hydra", 20, 15, 5);

            //mosnter 2
            _monster2 = new Monster("Naga", 15, 15, 10);

            _monster3 = new Monster("UW", 100, 30, 20);

            PrintStats(_monster1);
            PrintStats(_monster2);
        }

        void Update()
        {
            while (_monster1.health > 0 && _monster2.health > 0)
            {
                //hydra attacks naga
                Console.WriteLine(_monster2.name + " has taken " + Fight(_monster1, ref _monster2) + " damage.");

                Console.WriteLine(_monster1.name + " has taken " + Fight(_monster2, ref _monster1) + " damage.");

                PrintStats(_monster1);
                PrintStats(_monster2);
            }

            Monster winningMonster;
            if(_monster1.health <= 0)
            {
                winningMonster = _monster2;
            }
            else if (_monster2.health <= 0)
            {
                winningMonster = _monster1;
            }
            _gameOver = true;
        }

        void End()
        {
            Console.ReadKey();
        }
        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Update();
            }
            End();
        }

        float Fight(Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker.damage, defender.defense);
            defender.health -= damageTaken;
            return damageTaken;
        }

        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            //damage clamp method one
            if (damage <= 0) 
            {
                damage = 0;
            }

            return damage;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name:    " + monster.name);
            Console.WriteLine("Health:  " + monster.health);
            Console.WriteLine("Damage:  " + monster.damage);
            Console.WriteLine("Defense: " + monster.defense);
        }
    }
}
