using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class feed
    {
        public int NbUtilisation;
        //{
        public feed(string name, int puissance, string description, Item.PotionEffect e, int nbUtilisation)
            //: base(name, puissance, description, e)
        {
            NbUtilisation = nbUtilisation;
        }

        //public override void uses(Player p)
        //{
        //    if (NbUtilisation > 0)
        //    {
        //        base.Use(p);
        //        NbUtilisation--;
        //    }
        //}
    }

  }
