using System;
using System.Threading;

namespace Engine
{
    class Player
    {
        private int HP, Damage, Coins;
        private string Name;
        public void SetCoins(int SetCoin) { Coins += SetCoin; }
        public void SetHP(int SetHp) { HP += SetHp; }
        public void SetDamage(int SetDamage) { Damage += SetDamage;}
        public void SetName(string NewName) { Name = NewName; }
        public int GetHP() { return HP; }
        public int GetDamage() { return Damage; }
        public int GetCoins() { return Coins; } 
        public string GetName() { return Name; }
        public static void GetStats(int HP, int Damage, int Coins, string Name) { Console.WriteLine($"Hp: {HP}, Damage: {Damage}, Coins: {Coins}, your name: {Name}"); }
    }
    namespace Battles
    {
        class BattleV1
        {
            public static bool Sbattle_rus(int hp = 100, int damage = 15, int ehp = 70, int edamage = 23)
            {
                bool win = false;
                int nas;
                Random rand = new();
                do
                {
                    if (hp > 0)
                    {
                        nas = rand.Next(0, edamage);
                        Console.WriteLine("Вам нанесли " + nas + " урона, осталось " + hp + " hp");
                        hp -= nas;
                        Thread.Sleep(150);

                    }
                    else if (hp <= 0) { win = false; Console.WriteLine("Вы проиграли :("); };
                    if (ehp > 0)
                    {
                        nas = rand.Next(0, damage);
                        Console.WriteLine("Вы нанесли " + nas + " урона, у врага осталось " + ehp + " hp");
                        ehp -= nas;
                        Thread.Sleep(150);
                    }
                    else if (ehp <= 0) { win = true; Console.WriteLine("Победа!!"); };
                } while (hp > 0 & ehp > 0);

                if (win == false) { return false; }
                else { return true; }
            }
            public static bool Sbattle_eng(int hp = 100, int damage = 15, int ehp = 70, int edamage = 23)
            {
                bool win = false;
                int nas;
                Random rand = new();
                do
                {
                    if (hp > 0)
                    {
                        nas = rand.Next(0, edamage);
                        Console.WriteLine("you had  " + nas + " damage, you have " + hp + " hp");
                        hp -= nas;
                        Thread.Sleep(150);

                    }
                    else if (hp <= 0) { win = false; Console.WriteLine("lose :("); };
                    if (ehp > 0)
                    {
                        nas = rand.Next(0, damage);
                        Console.WriteLine("You bit enemy on " + nas + " damage, he's got " + ehp + " hp");
                        ehp -= nas;
                        Thread.Sleep(150);
                    }
                    else if (ehp <= 0) { win = true; Console.WriteLine("Win!"); };
                } while (hp > 0 & ehp > 0);

                if (win == false) { return false; }
                else { return true; }
            }
        }
        class BattleV2
        {
            public static bool Sbattle_rus(int hp = 100, int damage = 15, int ehp = 70, int edamage = 23)
            {
                return true;
            }
        }
    }
    namespace OuterSystems
    {
        class Language
        {
            public static string Lang() //Сдесь должен быть комментарий к методу, но его не будет!
            {
                Console.Write("Выбирете Язык/Choose language\n1.Русский(писать 1)\n2.english(write 2)\n>");
                string langc = Console.ReadLine();
                if (langc == "1" | langc == "русский" | langc == "Русский")//русский язык
                {
                    Console.WriteLine("выбран русский язык!");
                    Thread.Sleep(5000);
                    Console.Clear();
                    return "rus";
                }
                else//английский язык
                {
                    Console.WriteLine("english language has been choosen");
                    Thread.Sleep(5000);
                    Console.Clear();
                    return "eng";
                }
            }
        }
    }
}
