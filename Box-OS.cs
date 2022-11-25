/* 
 * Привет!
 * Надеюсь ты поймешь мой код, я постарался сделать переменные максимально понятными :)
 * Так же я посторался сделать максимально много комментариев :)
 * 
 * Дата начала проекта: 07.11.2022
 */

using System.Collections.Generic;
using System.Threading;

namespace Bios
{
    public class StartUp //это система запуска и одновременно что то вроде биоса, но упрощенного в 100 раз (может и больше)
    {
        public static void Main()
        {
            //Test();
            Console.WriteLine("Bios starup...");
            Thread.Sleep(300);
            Console.Clear();
            SysMain.SystemM1();
        }
        /*static void Test()
        {
            string[] A = Console.ReadLine().Split(new char[] {','});
            Console.WriteLine(A[0]);
            if (A[1] == "N")
            {
                Console.WriteLine("SUUU");
            }
            Thread.Sleep(5000);
        }*/
    }
}

namespace Box_OS
{
    public class SysMain
    {
        public static Core MyCmd = new();
        public static User MyUser = new();
        public static void SystemM1() //Это основной метод. он собрал в себя все необходимое из других классов :)
        {
            bool IsConsoleActive = true;
            User.Autorisation();
            MyCmd.CreateHisory("UserName = "+MyUser.Name);
            Console.WriteLine("Succefull enter!");
            Thread.Sleep(800);
            Console.Clear();
            Console.WriteLine($"Hi, {MyUser.Name}! What Do you want?");
            do  //А вот тут главная часть всей системы - консоль!
            {
                Console.Write(">C>");
                string[] lst = Console.ReadLine().Split('\u0020');
                try { MyCmd.DoAlgoritm(lst[0], lst[1]);}
                catch { MyCmd.DoAlgoritm(lst[0], "none"); }
                if (lst[0] == "SetOff" | lst[0] == "9") { IsConsoleActive = false; };
                
            } while (IsConsoleActive);  //Если вам показалось что тут маловато кода для основной системы - то вам определенно показалось...
        }
        public static void Help(string To_help = "main") //а теперь начинаются классы. Этот - класс для помощи (HELP)
        {
            List<string> Commands = new List<string> { "help", "delete", "game", "clear", "end", "href", "WinCMD", "open", "color {from 0 to 5}", "SetOff", "IdCheck" };
            if (To_help == "main")
            {
                Console.WriteLine("Command list:");
                foreach (string item in Commands)
                    Console.WriteLine(item);
                Console.WriteLine("example of help command >>> help <name of command>");
            }
            else if (To_help == "help") { Console.WriteLine("this command will help you understand commands in the command list :)"); }
            else if (To_help == "delete") { Console.WriteLine("this command will delete files on path, that you enter to console."); }
            else if (To_help == "game") { Console.WriteLine("this command will activate the game"); }
            else if (To_help == "clear") { Console.WriteLine("this command will clear the console"); }
            else if (To_help == "href") { Console.WriteLine("print the site ip or name, and it will start it :)"); }
            else if (To_help == "WinCMD") { Console.WriteLine("Enter after it command to Windows CMD"); }
            else if (To_help == "open") { Console.WriteLine("write after command path to file, and it will open"); }
            else if (To_help == "color") { Console.WriteLine("colorise the console!"); }
            else if (To_help == "SetOff") { Console.WriteLine("this command will Cutoff Box OS"); }
            else if (To_help == "IdCheck") { Console.WriteLine("write command and you will get his ID"); }
            else { Console.WriteLine("Command don't exist"); };
        }
    }
    public class User //а над этим я работал 2 часа и несколько раз переписывал...
    {
        public string Name, Password;
        public static bool IsAdmin;
        static List<string> UserNameList = new() { "aboba","Box", "Admin", "guest", "slave", "Guest"};
        static List<string> PasswordList = new() { "aboba","8246", "Admin", "guest", "box", "1234"};
        public static bool AdminCheck(string Name) //пригодится в будующем
        {
            if (Name == "BoX" | Name == "Admin")
            {
                IsAdmin = true;
                return true;
            }
            else
            {
                IsAdmin = false;
                return false;
            }
        }
        public bool AutorisationCheck(string name, string password) //Это метод авторизации пользователя.
        {
            try { name = Name; password = Password; } catch { }
            if (UserNameList.Contains(name) & PasswordList.Contains(password)) { return true; }
            else { return false; }
        }
        public static void Autorisation()
        {
            bool IsLogined;
            string Login, Password;
            do //тут находится система авторизации
            {
                Console.Write("Write Login: ");
                Login = Console.ReadLine();
                if (Login == "OsFast") { SysMain.MyUser.Name = "BoX"; break; };
                Console.Write("Write Password: ");
                Password = Console.ReadLine();
                SysMain.MyUser.Name = Login;
                SysMain.MyUser.Password = Password;
                IsLogined = SysMain.MyUser.AutorisationCheck(Login, Password);//не спраивайте меня почему readline'ы не в методе а отдельно...
                Console.Clear();
            } while (!IsLogined);// сдесь система авторизации заканчивается
        }
    }
}

/* На этом экскурсия по моему коду закончена!
 * Надеюсь вам понравилось :)
 */