using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Weapon
    {
        public int AtkBonus;


        public void testpcr(Monster target)
        {
            target.Hp -= ((AtkBonus - 2) * 3);
        }

        public void masque(Monster target)
        {
            target.Hp -= AtkBonus * 2;
        }



    }
}
