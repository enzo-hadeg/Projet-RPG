using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    abstract class Person
    {
        public string Name;
        public int Hp;
        public int Atk;
        public int Def;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Person(string name)
        {
            Name = name;
        }

        public virtual void damage(int amount)
        {
            Hp -= amount;
            if (Hp <= 0)
                Console.WriteLine("Couic");
        }

        public void prinstat()
        {
            Console.WriteLine("{0} stats:", Name);
            Console.WriteLine("");
            Console.WriteLine("Attack value is: {0}", Atk);
            Console.WriteLine("Health value is: {0}", Hp);
            Console.WriteLine("Health value is: {0}", Def);
        }

    }
}
