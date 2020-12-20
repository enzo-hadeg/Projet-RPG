using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Monster : Person
    {
        public enum MonsterKind { Covid, Corona, Macron}
        public Item Loot;
        public Monster(MonsterKind type, string name) : base(name)
        {
            switch (type)
            {
                case MonsterKind.Covid:
                    Hp = 100;
                    Atk = 1;
                    Def = 1;
                    PositionX = 7;
                    PositionY = 5;
                    Loot = new Item(Item.PotionEffect.Heal,"Heal",1,1);
                    break;
                case MonsterKind.Corona:
                    Hp = 2;
                    Atk = 3;
                    Def = 2;
                    PositionX = 7;
                    PositionY = 7;
                    Loot = new Item(Item.PotionEffect.Atk,"boum",1,1);
                    break;
                case MonsterKind.Macron:
                    Hp = 110;
                    Atk = 15;
                    Def = 8;
                    PositionX = 10;
                    PositionY = 9;
                    Loot = new Item(Item.PotionEffect.Atk, "charge", 1, 1);
                    
                    
                    break;

            }
        }

        public Monster() : base("")
        {

        }


        public override void damage(int amount)
        {
            base.damage(amount);
            if (Hp < 0)
                Console.WriteLine(Loot.Name);
        }

    }
}
