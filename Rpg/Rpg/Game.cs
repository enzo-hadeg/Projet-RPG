using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Game
    {
        private Player hero;
        private List<Monster> Monstres;
        private Boolean IsGameOver;
        private string ArenaName;
        private int CurrentLevel;

        public Game()
        {
            Monstres = new List<Monster>();

            Monstres.Add(new Monster(Monster.MonsterKind.Covid, "covid"));
            Monstres.Add(new Monster(Monster.MonsterKind.Macron, "corona"));
            Monstres.Add(new Monster(Monster.MonsterKind.Corona, "virus"));
            Monstres.Add(new Monster(Monster.MonsterKind.Covid, "virus"));
            Story.macron();

            Console.WriteLine("1:BAGARREUR 2:HARRY");

            int ch = choixMenu(2);

            switch (ch)
            {
                case 1:
                    hero = new Player(Player.Role.Warrior, "Garen");
                    break;
                case 2:
                    hero = new Player(Player.Role.Mage, "Harry");
                    break;
                default:
                    hero = new Player(Player.Role.Warrior, "Garen");
                    break;

            }
            CurrentLevel = 0;


            Combat();

        }


        private void Combat()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];


            Console.WriteLine("*********************************************************************************");
            Console.WriteLine("\n\t\t\t\tBIENVENUE  \n\n\tChoisissez : \n*\t1:Atk \n*\t2:Approcher Le Monstre \n*\t3:Inventaire \n*\t4:Fuir");
            Console.WriteLine("*********************************************************************************");
            bool finish = false;
            while (p.Hp> 0 && !finish)
            {
                int choix = choixMenu(3);
                switch(choix)
                {
                    case 1:
                        Attaque();
                        if(m.Hp <= 0)
                        {
                            Console.WriteLine($"=====>{p.Name} gagne le combat contre le monster {m.Name}");
                            p.Inventory.Add(m.Loot);
                            Console.WriteLine();
                            Console.WriteLine($"{p.Name} a recu une nouveau objet {m.Loot.Name}, Power: {m.Loot.PotionPower}");
                            m = GetNextMonster();
                            if(m==null)
                            {
                                Console.WriteLine($"{p.Name} remporte la victoire sur tous les monsters({Monstres.Count}) sur ce territoire");
                                finish = true;
                            }else
                            {
                                Console.WriteLine($"=====>{p.Name} va combatre le monster {m.Name}");

                                switch (m.Name)
                                {
                                    case "covid":
                                        Story.covid();
                                        break;
                                    case "virus":
                                        Story.virus();
                                        break;
                                    default:
                                        Story.covid();
                                        break;
                                }
                            }

                        }
                        break;
                    case 2:
                        GoToMonster();
                        break;
                    case 3:
                        OpenInventory();
                        break;
                    case 4:
                        Quit();
                        break;
                }

                Console.WriteLine("*****************************Position Initiale*****************************");
                ShowMap(hero, Monstres[CurrentLevel]);
                Console.WriteLine("\n\t  \n\tChoisissez : 1:Atk 2:ApprocherM 3:Inventaire 4:Fuir");
            }

            if (p.Hp>0)
            {
                Console.WriteLine("Bravo");
                hero.Inventory.Add(m.Loot);
                Combat();
            }
            else
            {
                Console.WriteLine("*****************************Vous avez perdu*****************************");
                Console.WriteLine("Vous Voulez Recommancer ? Oui [o], Non[n]");
                var decision = Console.ReadLine();
                if (decision.ToLower().StartsWith("o"))
                {
                    p.Hp = 100;
                    m.Hp = 100;
                }else
                    Quit();
            }
        }

        private Monster GetNextMonster()
        {
            CurrentLevel++;
            if (CurrentLevel < Monstres.Count)
                return Monstres[CurrentLevel];
            else
                return null;
        }

        private void GoToMonster()
        {
            Monster m = Monstres[CurrentLevel];
            if (hero.PositionX == m.PositionX)
                hero.PositionY = m.PositionY - 1;
            else if (hero.PositionY == m.PositionY)
                hero.PositionX = m.PositionX - 1;
            else if(hero.PositionX < m.PositionX)
            {
                hero.PositionX = m.PositionX - 1;
                hero.PositionY = m.PositionY;
            }else
            {
                hero.PositionX = m.PositionX;
                hero.PositionY = m.PositionY - 1;
            }
        }

        private void OpenInventory()
        {
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                Console.WriteLine((i+1) +":"+hero.Inventory[i].Name);
            }
            Console.WriteLine((hero.Inventory.Count +1) + ":" + "Return to Battle");

            int choix = choixMenu(hero.Inventory.Count+1);

            if ((hero.Inventory.Count + 1) == choix)
                return;

            hero.Inventory[choix - 1].Use(hero);

            if (hero.Inventory[choix - 1].NumberOfUse <= 0)
                hero.Inventory.RemoveAt(choix - 1);
        }

        private void Attaque()
        {
            Player p = hero;
            Monster m = Monstres[CurrentLevel];

            if ((p.PositionX == m.PositionX && Math.Abs(p.PositionY-m.PositionY)<2)
                || (p.PositionY == m.PositionY && Math.Abs(p.PositionX - m.PositionX) < 2))
            {
                m.Hp -= Math.Clamp(p.Atk - m.Def, 0, 100);
                p.Hp -= Math.Clamp(m.Atk - p.Def, 0, 100);

                Console.WriteLine(p.Name + " a encore " + p.Hp + " Hp");
                Console.WriteLine(m.Name + " a encore " + m.Hp + " Hp");
            } else
                Console.WriteLine($"{p.Name} a besoin d'etre proche du monster {m.Name}");

        }


        private void ShowMap(Player p, Monster m)
        {
            for (int i=0; i<15; i++)
            {
                for(int j=0; j<15; j++)
                {
                    if (p.PositionX == i && p.PositionY == j)
                        Console.Write("P");
                    else if (m.PositionX == i && m.PositionY == j)
                        Console.Write("M");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        public int choixMenu(int max)
        {
            Boolean choixValide = false;
            int choix = 0;
            while (choixValide != true)
            {
                int.TryParse(Console.ReadLine(), out choix);
                while(choix!=1 && choix != 2 && choix != 3 && choix != 4)
                {
                    Console.WriteLine(choix + " Entrée incorrecte. Veuillez réessayer.");
                    int.TryParse(Console.ReadLine(), out choix);
                }
                if ((int)choix > 0 && (int)choix <= max)
                {
                    choixValide = true;
                }
                else
                {
                    Console.WriteLine(choix + " Entrée incorrecte. Veuillez réessayer.");
                }
            }
            return (int)choix;
        }



        public static void Quit()
        {
            Environment.Exit(0);
        }

        public void save()
        {

        }

        public void Load()
        {

        }
    }
}
