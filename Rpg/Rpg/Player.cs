using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Player : Person
    {
        private static int UniquePosition=0;
        public enum Role { Warrior, Mage }

        public Role r;

        public List<Item> Inventory;

        public Player(Role role, string name) : base(name)
        {
            r = role;
            PositionX =5 + UniquePosition;
            PositionY =5 + UniquePosition;
            UniquePosition += 2;
            Inventory = new List<Item>();
            Inventory.Add(new Item(Item.PotionEffect.Heal, "heal", 5, 2));
            Inventory.Add(new Item(Item.PotionEffect.Atk, "Atk", 5, 2));

            switch (role)
            {
                case Role.Warrior:
                    Hp = 10;
                    Atk = 10;
                    Def = 10;
                    break;
                case Role.Mage:
                    Hp = 5;
                    Atk = 25;
                    Def = 5;
                    break;

            }


        }
        public void attq(int decision, Monster target)
        {
            if (decision == 1)
            {
                //NormAttack(target);
                Console.WriteLine("vous avez attaquer lennemie!");
            }

            if (decision == 2)
            {
                //Hp();
                Console.WriteLine("soins: {0} hp!");
            }

            if (decision == 4)
            {
                //SpinAttack(target);
                Console.WriteLine("attaque pcr!");
            }

            if (decision == 5)
            {
                //DoubleSlash(target);
                Console.WriteLine("attaque masque!");
            }
        }
    }
}
