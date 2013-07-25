using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Mediator
{

    class Unit
    {
        public int Strength { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Sword Sword { get; set; }

        public void Attack()
        {
            Console.WriteLine("Unit.Attack!");
        }

    }

    class Sword
    {
        public int Damage { get; set; }
        /// <summary>
        /// from 100 to 0. 0 - broken
        /// </summary>
        public int Durability { get; set; }
    }

    /// <summary>
    /// mediator methods contain buisness logic operations for many components
    /// </summary>
    class Mediator
    {
        private Unit _attacker;
        private Unit _defender;

        void Attack()
        {
            _attacker.Attack();
            var attackerClearDamage = (_attacker.Strength / 100) * _attacker.Sword.Damage;
            var brokenSwordPenalty = _attacker.Sword.Durability * 100;
            _defender.Health -= attackerClearDamage * brokenSwordPenalty;

            //simplify:
            var _defenderHealthDamage = 
            //after each atack sword is crushed 
            _attacker.Sword.Durability -= _attacker.Strength / 10;
        }

        void RepairSwords(int durabilityBinus)
        {
            _sword.Durability += durabilityBinus;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleApp_Mediator");

            Console.ReadKey();
        }
    }
}
