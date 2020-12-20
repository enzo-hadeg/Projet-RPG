using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Combat
    {
        public static void persondead(Person person)
        {
            if (person.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine("oups t'es mort");
                Console.WriteLine("j'arrive te déterrer de ta tombe noob");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }
        public static void prinstat(Person person1, Person person2)
        {
            person1.prinstat();
            Console.WriteLine("");
            person2.prinstat();
            Console.WriteLine("");

        }
        public static void monstres(Person person, Monster monster)
        {
            while (monster.Hp >0 && person.Hp>0)
            {
                prinstat(monster, person);
                //person.
            }
        }

    }  
 }

