/* 
 * Это Код игры Симулятор консольного квеста 2
 * Посторайся его понять и принять :)
 */

using System;
using System.Threading;
using Engine;
using Engine.Battles;
using Engine.OuterSystems;



namespace Main_Game
{
    class Game_sys
    {
        public static string Lang = "NoLang";
        public static void Game()
        {
            Console.WriteLine("Запуск игры...");
            Thread.Sleep(1252);
            Console.WriteLine("Приятного прохождения!\n");
            string lang;
            if (Lang == "rus") { lang = "rus"; }
            else if (Lang == "eng") { lang = "eng"; }
            else { lang = Language.Lang();};
            if (lang == "rus")
            {
                Russian.Epizode1();
                Console.Write("Игра закончилась!\nХорошего дня!");
            }
            else if (lang == "eng")
            {
                English.Epizode1();
                Console.Write("Game ended\nGame finished!");
            }
            Console.ReadKey();
        }
        public static void Restart(int Epizode, string Langu)
        {
            if (Langu == "rus")
            {
                if (Epizode == 1) { Russian.Epizode1(); }
            }
            else if (Langu == "eng")
            {
                if (Epizode == 1) { English.Epizode1(); }
            }
        }
    }
    class Russian : Player
    {
        public static Player Gamer = new();
        public static void Epizode1()
        {
            string choose;
            Console.WriteLine("Эпизод 1");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Добро пожаловать в симулятор консольного квеста 2! (написан на с#, а не python)");
            Console.WriteLine("После победы над Боссом в 1 части вы пошли в лес.\nВы нашли дом мага!.");
            Console.Write("Он попросил сказать волшебное слово, и он подарит вам что-то хорошее!\n>");
            choose = Console.ReadLine();
            if (choose == "oh shit im sorry")
            {
                Console.Write("-Сколько ты хочешь хп, мой друг?\n>");
                try { Gamer.SetHP(Convert.ToInt32(Console.ReadLine())); } catch (FormatException) { Gamer.SetHP(150); Console.WriteLine("Вы ввели не число => в качестве штрафа ваше хп - 150"); } catch { Console.WriteLine("IDK what is error :)"); }
                Console.Write("-Сколько урона тебе нужно для победы?\n>");
                try { Gamer.SetDamage(Convert.ToInt32(Console.ReadLine())); } catch(FormatException) { Gamer.SetDamage(150); Console.WriteLine("Вы ввели не число => в качестве штрафа ваш урон - 150"); } catch { Console.WriteLine("IDK what is error :)"); }
                Console.Write("-А как же тебя зовут, путник?\n>");
                try { Gamer.SetName(Console.ReadLine()); } catch { Gamer.SetName("Player"); }
                Console.WriteLine("-Прощай, путник! Пусть дорога твоя будет без приключений!\nСказал маг, дал 900 монет и ушел домой.");
                Gamer.SetCoins(900);
                GetStats(Gamer.GetHP(), Gamer.GetDamage(), Gamer.GetCoins(), Gamer.GetName());
            }
            else
            {
                Console.Write("Неожиданно ты забываешь свое имя :(\nВидимо тебе нужно придумать новое\nКак тебя зовут?\n>");
                Gamer.SetName(Console.ReadLine()); Gamer.SetHP(100); Gamer.SetDamage(10); Gamer.SetCoins(100);
                Console.Write("Ваши характеристики: ");
                GetStats(Gamer.GetHP(), Gamer.GetDamage(), Gamer.GetCoins(), Gamer.GetName());
            }
            Ebizode2();
        }
        public static void Ebizode2()
        {
            Console.Clear();
            Console.WriteLine("Эпизод 2");
            Console.WriteLine("Вы пришли к своему дому!");
            House_rus.ComeInHouse_rus(true);
            if (House_rus.Rub100 == true) { Gamer.SetCoins(100); }
        }
    }
    class House_rus
    {
        
        void CCS() {Thread CC = new(ClearConsole);; CC.Start();}
        private static bool KnifeInYashik = false, ButtonIsOpened = false, KnifeInSafe = false, coins1 = false, coins2 = false;
        public static bool Rub100 = false;
        private static int TryCount;
        public static void ComeInHouse_rus(bool FirstTime = false)
        {
            House_rus House = new();
            House.CCS();
            if (FirstTime) { Console.Write("Вы вошли в свой дом!\nС чего хотите начать?\n1.Спальня\n2.гостинная\n3.подвал\n4.кухня\n>"); }
            else { Console.Write("Куда пойдете?\n1.Спальня\n2.Гостинная\n3.Подвал\n4.Кухня\n>"); };
            string choose = Console.ReadLine();
            if (choose == "1" | choose == "Спальня" | choose == "спальня") { Room1(); }
            else if (choose == "2" | choose == "Гостинная" | choose == "гостинная") { Room2(); }
            else if (choose == "3" | choose == "Подвал" | choose == "подвал") { }
            else if (choose == "4" | choose == "Кухня" | choose == "кухня") { }
            else { ComeInHouse_rus(); }
        }
        private void ClearConsole()
        {
            do
            {
                if (TryCount > 5) { Console.Clear(); }
            }while(true);
        }
        public static void Room1()
        {
            bool IsIn = true;
            do
            {
                Console.WriteLine("В спальне вы обнаруживайте:\n1.шкаф(отсылка на СКК1)\n2.Ящик(тоже отсылка)\n3.Кровать\n4.Какая-то хрень из которой вылезет монстр\n5.Выйти из команты");
                Console.Write(">");
                string choose = Console.ReadLine();
                if (choose == "1" | choose == "шкаф" | choose == "Шкаф" | choose == "шкаф(отсылка на СКК1)") { Shkaf(); }
                if (choose == "2" | choose == "Ящик" | choose == "ящик" | choose == "Ящик(тоже отсылка)") {Yashik();}
                if (choose == "3" | choose == "Кровать" | choose == "кровать") { Bed(); }
                if (choose == "4" | choose == "хрень" | choose == "Какая-то хрень из которой вылезет монстр") { Shit(); }
                if (choose == "5" | choose == "выйти" | choose == "Выйти"| choose == "Выйти из команты") { IsIn = false; }
                TryCount++;
            } while (IsIn);
        }
        private static bool Shkaf()
        {
            string choose;
            Console.WriteLine("Вы открыли шкаф!");
            do
            {
                Console.Write("Что вы хоите сделать?\n1.Взять 100 рублей\n2.Нажать кноопку\n3.\n4.\nЕсли ничего - 5\n>");
                choose = Console.ReadLine();
                if (choose == "5" | choose == "Если ничего - 5") { break; }
                else if (choose == "1" | choose == "1.Взять 100 рублей") { if (!Rub100) { Rub100 = true; Console.WriteLine("Вы взяли 100 рублей"); } else { Console.WriteLine("Вы уже взяли 100 рублей!"); } }
                else if (choose == "2" | choose == "2.Нажать кнопку") { ButtonIsOpened = true; Console.WriteLine("Вы услышали какой-то звук..."); }
                TryCount++;
            } while (true);
            return false;
        }
        private static void Yashik()
        {
            Console.WriteLine("В ящике вы видите:\n1.Сейф\n2.Ножик для резки бананов");
            string choose = Console.ReadLine();
            if (choose == "1" | choose == "Сейф" | choose == "сейф") { if (ButtonIsOpened) { Console.WriteLine("Сейф открыт!"); Safe(); } else { Console.WriteLine("Несмотря на то, что сейф ваш, вы не помните как его открыть..."); } }
            else if (choose == "2" | choose == "Нож" | choose == "2.Ножик для резки бананов") { if (KnifeInYashik) { Russian.Gamer.SetDamage(5); Console.WriteLine("Вы взяли нож!"); KnifeInYashik = true; } else { Console.WriteLine("Нож уже у вас!"); } }
            TryCount++;
        }
        private static void Safe()
        {
            Console.Write("Вы открыли сейф! В нем есть: \n1.Меч короля Картофеля\n2.100 рублей\n>");
            string choose = Console.ReadLine();
            if (choose == "100 рублей" | choose == "2") { if (!coins1) { Russian.Gamer.SetCoins(100); Console.WriteLine("Вы взяли 100 рублей"); } }
            else if (choose == "Меч короля Картофеля" | choose == "1") { if (KnifeInSafe) { Russian.Gamer.SetDamage(10); Console.WriteLine("Вы взяли меч!"); KnifeInSafe = true; } else { Console.WriteLine("Меч уже у вас!"); } }
        }
        private static void Bed()
        {
            Thread.Sleep(7000);
            Console.WriteLine("Вы поспали!");
        }
        private static void Shit()
        {
            bool Win = BattleV1.Sbattle_rus(Russian.Gamer.GetHP(), Russian.Gamer.GetDamage(), 50, 15);
            if (Win) { Russian.Gamer.SetCoins(25); Console.WriteLine("Вы победили монстра, и забрали у него 25 монет!"); }
        }
        public static void Room2()
        {
            Console.WriteLine("Вы вошли в гостинную!\n1.\n2.\n3.\n4.");
        }
        public static void SetFalseAll() { KnifeInSafe = false; KnifeInYashik = false; ButtonIsOpened = false; }
    }
    class English : Player
    {
        public static Player Gamer = new();
        public static void Epizode1()
        {
            string choose;
            Console.WriteLine("Epizode1");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Welcome to Console Quest Simulator 2! (written in c#, not python)");
            Console.WriteLine("After defeating the Boss in Part 1, you went to the forest.\nYou found the wizard's house!");
            Console.Write("He asked you to say a magic word, and he'll give you something good!\n>");
            choose = Console.ReadLine();
            if (choose == "oh shit im sorry")
            {
                Console.Write("-How much hp do you want, my friend?\n>");
                try { Gamer.SetHP(Convert.ToInt32(Console.ReadLine())); } catch (FormatException) { Gamer.SetHP(150); Console.WriteLine("You entered a wrong number => your xp is 150 as a penalty"); } catch { Console.WriteLine("IDK what is error :)"); }
                Console.Write("-How much damage do you need to win?\n>");
                try { Gamer.SetDamage(Convert.ToInt32(Console.ReadLine())); } catch (FormatException) { Gamer.SetDamage(150); Console.WriteLine("You entered a wrong number => your damage is 150 as a penalty"); } catch { Console.WriteLine("IDK what is error :)"); }
                Console.Write("-What's your name, traveler?\n>");
                try { Gamer.SetName(Console.ReadLine()); } catch { Gamer.SetName("Player"); }
                Console.WriteLine("-Farewell, traveler! Said the magician, gave 900 coins, and went home.");
                Gamer.SetCoins(900);
                GetStats(Gamer.GetHP(), Gamer.GetDamage(), Gamer.GetCoins(), Gamer.GetName());
            }
            else
            {
                Console.Write("Suddenly you forget your name :(\nI guess you need to think of a new one\n What's your name? \n>");
                Gamer.SetName(Console.ReadLine()); Gamer.SetHP(100); Gamer.SetDamage(10); Gamer.SetCoins(100);
                Console.Write("Your characteristics: ");
                GetStats(Gamer.GetHP(), Gamer.GetDamage(), Gamer.GetCoins(), Gamer.GetName());
            }
            Ebizode2();
        }
        public static void Ebizode2()
        {
            Console.Clear();
            Console.WriteLine("Episode 2");
            Console.WriteLine("You have come to your house!");
            House_rus.ComeInHouse_rus(true);
            if (House_rus.Rub100 == true) { Gamer.SetCoins(100); }
        }
    }
    public class House_eng
    {
        private static bool CodeApply, ButtonIsOpened;
        public static bool Rub100 = false;
        public static void ComeInHouse_rus(bool FirstTime = false)
        {
            if (FirstTime) { Console.Write("Вы вошли в свой дом!\nС чего хотите начать?\n1.Спальня\n2.гостинная\n3.подвал\n4.кухня\n>"); }
            else { Console.Write("Куда пойдете?\n1.Спальня\n2.Гостинная\n3.Подвал\n4.Кухня\n>"); };
            string choose = Console.ReadLine();
            if (choose == "1" | choose == "Спальня" | choose == "спальня") { Room1(); }
            else if (choose == "2" | choose == "Гостинная" | choose == "гостинная") { Room2(); }
            else if (choose == "3" | choose == "Подвал" | choose == "подвал") { }
            else if (choose == "4" | choose == "Кухня" | choose == "кухня") { }
            else { ComeInHouse_rus(); }
        }
        public static void Room1()
        {
            bool IsIn = true;
            do
            {
                Console.WriteLine("В спальне вы обнаруживайте:\n1.шкаф(отсылка на СКК1)\n2.Ящик(тоже отсылка)\n3.Кровать\n4.Какая-то хрень из которой вылезет монстр\n5.Выйти из команты");
                Console.Write(">");
                string choose = Console.ReadLine();
                if (choose == "1" | choose == "шкаф" | choose == "Шкаф" | choose == "шкаф(отсылка на СКК1)") { Shkaf(); }
                if (choose == "2" | choose == "Ящик" | choose == "ящик" | choose == "Ящик(тоже отсылка)") { Yashik(); }
                if (choose == "3" | choose == "Кровать" | choose == "кровать") { Bed(); }
                if (choose == "4" | choose == "хрень" | choose == "Какая-то хрень из которой вылезет монстр") { Shit(); }
                if (choose == "5" | choose == "выйти" | choose == "Выйти" | choose == "Выйти из команты") { IsIn = false; }
            } while (IsIn);
        }
        private static bool Shkaf()
        {
            string choose;
            Console.WriteLine("Вы открыли шкаф!");
            do
            {
                Console.Write("Что вы хоите сделать?\n1.Взять 100 рублей\n2.Нажать кноопку\n3.\n4.\nЕсли ничего - 5\n>");
                choose = Console.ReadLine();
                if (choose == "5" | choose == "Если ничего - 5") { break; }
                else if (choose == "1" | choose == "1.Взять 100 рублей") { Console.WriteLine("Вы взяли 100 рублей :)"); Rub100 = true; }
                else if (choose == "2" | choose == "2.Нажать кнопку") { ButtonIsOpened = true; Console.WriteLine("Вы услышали какой-то звук..."); }
            } while (true);
            return false;
        }
        private static void Yashik()
        {

        }
        private static void Bed()
        {

        }
        private static void Shit()
        {
            bool Win = BattleV1.Sbattle_rus(Russian.Gamer.GetHP(), Russian.Gamer.GetDamage(), 50, 15);
            if (Win) { Russian.Gamer.SetCoins(25); Console.WriteLine("Вы победили монстра, и забрали у него 25 монет!"); }
        }
        public static void Room2()
        {

        }
        
    }
}