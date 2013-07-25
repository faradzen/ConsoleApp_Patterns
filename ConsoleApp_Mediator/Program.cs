using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Mediator
{
    class Unit
    {
        public string Name { get; set; }

        public void Attack()
        {
            Console.WriteLine("Unit-{0}.Attack!", Name);
        }
        public void Defend()
        {
            Console.WriteLine("Unit-{0}.Defend", Name);
        }
    }

    /// <summary>
    /// mediator methods contain buisness logic operations for many components
    /// </summary>
    class MediatorBetweenUnits
    {
        private Unit _attacker;
        private Unit _defender;

        public void RegisterAttacker(Unit attacker)
        {
            _attacker = attacker;
        }
        public void RegisterDefender(Unit defender)
        {
            _defender = defender;
        }

        public void AttackWithDefend()
        {
            _attacker.Attack();
            _defender.Defend();
        }

        public void SurpriseAttack()
        {
            Console.WriteLine("Surprise!");
            _attacker.Attack();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleApp_Mediator");
            var a = new Unit { Name = "Alice" };
            var d = new Unit { Name = "Dan" };
            var m = new MediatorBetweenUnits();
            m.RegisterAttacker(a);
            m.RegisterDefender(d);

            m.AttackWithDefend();
            m.SurpriseAttack();
            m.SurpriseAttack();

            Console.ReadKey();
        }
    }
}
