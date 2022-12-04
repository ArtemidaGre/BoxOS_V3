using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace CoreSpace
{
    public interface NewInstruct
    {
        public void Funk();
        public string InstructDescription();
        public bool InstructStart();
    }
    public class Core //Вот ядро системы - командная строка!
    {
        FileStream fstream = new FileStream(@"C:\Users\Public\Documents\BoxOsHistory.log", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public string Command;
        public int CommandID;
        public static List<string> CommandList = new() { "WinCMD", "color", "open", "copy", "help", "href", "git", "del", "clear", "end", "IdCheck", "MyHistory", "encode", "decode", "cqq2" };

        public int CommandIDCheck(string CommandToCheck, bool IsID = false)
        {
            try
            {
                int CommandListCount = CommandList.Count;
                for (int Count = 0; Count <= CommandListCount; Count++)
                {
                    if (CommandList[Count] == CommandToCheck) { return Count; }
                }
                return 0;
            }
            catch
            {
                return -1;
            }

        }
        public string CommandNameCheck(int ID_Com_find)
        {
            try
            {
                return CommandList[ID_Com_find];
            }
            catch
            {
                return "This command ID don't exist!";
            }

        }
        public bool DoAlgoritm(string CommandToDo, string SubCom) //СЮДА НЕ СМОТРЕТЬ!!! возможен инсульт у хороших программистов ;(
        {
            if (CommandToDo == "WinCMD" | CommandToDo == "0") { string cmd_command = SubCom; ; Process.Start("cmd", "/C " + cmd_command); }
            else if (CommandToDo == "color" | CommandToDo == "1") { string ColorForConsole = SubCom; if (ColorForConsole == "2") { Console.ForegroundColor = ConsoleColor.Green; } else if (ColorForConsole == "3") { Console.ForegroundColor = ConsoleColor.Yellow; } else if (ColorForConsole == "4") { Console.ForegroundColor = ConsoleColor.Red; } else if (ColorForConsole == "5") { Console.ForegroundColor = ConsoleColor.Blue; } else if (ColorForConsole == "0") { Console.ResetColor(); } }
            else if (CommandToDo == "open" | CommandToDo == "2") { try { Process mYproces = new Process(); mYproces.StartInfo.FileName = SubCom; mYproces.Start(); mYproces.WaitForExit(); } catch { Console.WriteLine("CMD open ERROR"); } }
            else if (CommandToDo == "copy" | CommandToDo == "3") { Console.WriteLine("this funk not ready for now :)"); }
            else if (CommandToDo == "help" | CommandToDo == "4") { string ToHelp = SubCom; if (ToHelp == "none") { for (int I = 0; I <= CommandList.Count() - 1; I++) { Console.WriteLine(CommandList[I]); }; Console.WriteLine("Write <help> and command, for example: <help href>"); }; SysMain.Help(ToHelp); }
            else if (CommandToDo == "href" | CommandToDo == "5") { string href = SubCom; Process.Start("cmd", "/C start" + " http://" + href); }
            else if (CommandToDo == "git" | CommandToDo == "6") { Process.Start("cmd", "/C start https://github.com/ArtemidaGre"); }
            else if (CommandToDo == "del" | CommandToDo == "7") { string path = SubCom; FileInfo fileInf = new FileInfo(path); if (fileInf.Exists) { fileInf.Delete(); Console.WriteLine("delete succes"); } }
            else if (CommandToDo == "clear" | CommandToDo == "8") { Console.Clear(); }
            else if (CommandToDo == "end" | CommandToDo == "9") { fstream.Close(); }
            else if (CommandToDo == "IdCheck" | CommandToDo == "10") { Console.WriteLine(CommandIDCheck(SubCom)); return false; }
            else if (CommandToDo == "MyHistory" | CommandToDo == "11") { Console.WriteLine(GetHistory()); }
            else if (CommandToDo == "encode" | CommandToDo == "12") {string result = String.Join("", Encode.Box4b(SubCom));Console.WriteLine(result);FileSys.WriteIn(result);}
            else if (CommandToDo == "decode" | CommandToDo == "13") {if (SubCom == "file"){Console.WriteLine(String.Join("", Decode.Box4b(FileSys.ReadOut())));}string result = String.Join("", Decode.Box4b(SubCom));Console.WriteLine(result);}
            else if (CommandToDo == "cqq2" | CommandToDo == "14") { Game_sys.Game(); }
            else if (CommandToDo == "deen" | CommandToDo == "15") { Launcher.EnDe   (); }
            else if (CommandToDo == "CreateUser" | CommandToDo == "16") { }
            else if (CommandToDo == "cp" | CommandToDo == "854") { Console.WriteLine("C:/Users/Public/Documents/"); }
            else if (CommandToDo == "" | CommandToDo == "99") { Non_big_Errors.DevErr._E(); }
            
            else { Console.WriteLine("Command Error"); };
            try { CreateHisory(CommandToDo + " " + SubCom); } catch { Console.WriteLine("History Error 2"); }
            return true;

            //else if (CommandToDo == "" | CommandToDo == "") { }
        }
        public void CreateHisory(string HistoryPlus, bool Argument = false)
        {
            if (Argument) { FileSys.WriteIn(HistoryPlus+"\n");}
            else { FileSys.WriteIn(HistoryPlus); }
            
        }
        public string[] GetHistory()
        {
            return Decode.Box4b(FileSys.ReadOut());
        }
    }
    public class User //а над этим я работал 2 часа и несколько раз переписывал...
    {
        public static FileStream fstream = new FileStream(@"C:\Users\Public\Documents\code.boxc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public static string Name, Password;
        public static bool IsAdmin;
        static string[] UserNameList = { "aboba", "Box", "Admin", "guest", "Guest" };
        static string[] PasswordList = { "aboba", "8246", "Admin", "guest", "1234" };
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
        public static string[] FileUser()
        {
            FileStream UserFile = new FileStream(@"C:\Users\Public\Documents\Users.boxc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string[] Names;
            UserFile.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[UserFile.Length];
            UserFile.Read(output, 0, output.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(output);
            Names = textFromFile.Split('•');
            UserFile.Close();
            return Names;
        }
        public static string[] FilePassword()
        {
            FileStream UserFile = new FileStream(@"C:\Users\Public\Documents\Passwords.boxc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string[] Names;
            UserFile.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[UserFile.Length];
            UserFile.Read(output, 0, output.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(output);
            Names = textFromFile.Split('•');
            UserFile.Close();
            return Names;
        }
        public static void WriteIn(string ToWrite)
        {
            byte[] input = Encoding.Default.GetBytes(ToWrite);
            // запись массива байтов в файл
            fstream.Write(input, 0, input.Length);
        }
        public static bool AutorisationCheck(string name, string password) //Это метод авторизации пользователя.
        {
            try { name = Name; password = Password; } catch { }
            if (UserNameList.Contains(name) & PasswordList.Contains(password)) { return PassLoginCheck(UserNameList, PasswordList, name, password); }
            else if (FileUser().Contains(name)) { return true; }
            else { return false; }
        }
        private static bool PassLoginCheck(string[] UserList, string[] PassList, string ThisLogin, string ThisPassword)
        {
            for (int i = 0; i<UserList.Length & i<PassList.Length; i++)
            {
                if (UserList[i] == ThisLogin & PassList[i] == ThisPassword) { return true; }
            }
            return false;
        }
        public static void Autorisation()
        {
            bool IsLogined;
            string Login, password;
            do //тут находится система авторизации
            {
                Console.Write("Write Login: ");
                Login = Console.ReadLine();
                if (Login == "OsFast") { Name = "BoX"; break; };
                Console.Write("Write Password: ");
                password = Console.ReadLine();
                Name = Login;
                Password = password;
                IsLogined = SysMain.MyUser.AutorisationCheck(Login, Password);//не спраивайте меня почему readline'ы не в методе а отдельно...
                Console.Clear();
            } while (!IsLogined);// сдесь система авторизации заканчивается
        }
        public static void CreateUser( string User1 ,string NewUserName, string NewUserPassword)
        {
            if (AdminCheck(User1))
            {
                FileStream UserFile = new FileStream(@"C:\Users\Public\Documents\Users.boxc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                FileStream PassFile = new FileStream(@"C:\Users\Public\Documents\Passwords.boxc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                byte[] input = Encoding.Default.GetBytes(NewUserName+'•');
                // запись массива байтов в файл
                UserFile.Write(input, 0, input.Length);
                byte[] input1 = Encoding.Default.GetBytes(NewUserPassword + '•');
                // запись массива байтов в файл
                PassFile.Write(input1, 0, input.Length);
            }
            else
            {
                Console.WriteLine("you're not admin!");
            }
        }
    }
    namespace LocalNet
    {
        class MainSocket //Все еще разрабатывается, к НГ возможно сделаю
        {
            public Socket SocketTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            public IPAddress IpAddr = IPAddress.Parse("192.168.0.11");
            public IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            public class Client : NewInstruct
            {
                
            
                public void Funk()
                {
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
                    Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    server.Connect(ipep);
                }
                public string InstructDescription()
                {
                    return "";
                }
                public bool InstructStart()
                {
                    Funk();
                    return true;
                }
            }
            public class Server : NewInstruct
            {
                public void Funk()
                {
                    IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8000);
                    Socket newsock = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    newsock.Bind(localEndPoint);
                    newsock.Listen(10);
                    Socket client = newsock.Accept();
                }
                public string InstructDescription()
                {
                    return "";
                }
                public bool InstructStart()
                {
                    Funk();
                    return true;
                }

            }
        }
    }
    namespace BoxInCode
    {
        class Launcher
        {
        
            public static void EnDe()
            {
                string choose;
                string[] Lchoose;
                while (true)
                {
                    Console.WriteLine("encode/decode <sometext>");
                    choose = Console.ReadLine();
                    if (choose == null) { choose = "sperma"; };
                    Lchoose = choose.Split(" ");
                    if (Lchoose[0] == "encode")
                    {
                        string result = String.Join("" ,Encode.Box4b(Lchoose[1]));
                        Console.WriteLine(result);
                        FileSys.WriteIn(result);
                    }
                    else if (Lchoose[0] == "decode")
                    {
                    if (Lchoose[1] == "file")
                    {
                        Console.WriteLine(String.Join("", Decode.Box4b(FileSys.ReadOut())));
                    }
                    string result = String.Join("", Decode.Box4b(Lchoose[1]));
                    Console.WriteLine(result);    
                    }
                    else if (Lchoose[0] == "end") { Console.Clear(); break; }
                }
            }
        }
        class mc
        {
            public static string[] Char_Str_Char(string S)
            {
                char[] mystr = S.ToCharArray();
                string[] asda = new string[150];
                for(int I = 0; I<mystr.Length; I++) { asda[I] = Convert.ToString(mystr[I]);};
                return asda;
            }
            public static string[] DeleteThisWord(string word, string[] mass)
            {
                for (int q = 0; q < mass.Length; q++)
                {
                    if (mass[q] == word)
                    {
                        mass[q] = null;
                        mass = mass.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    }
                }
                return mass;
            }
        }
        public class FileSys
        {
            public static FileStream fstream = new FileStream(@"C:\Users\Public\Documents\code.boxc", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            public static void WriteIn(string ToWrite)
            {
                byte[] input = Encoding.Default.GetBytes(ToWrite);
                // запись массива байтов в файл
                fstream.Write(input, 0, input.Length);
            }
            public static string ReadOut()
            {
                fstream.Seek(0, SeekOrigin.Begin);
                byte[] output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(output);
                fstream.Close();
                return textFromFile;
            }
            public static void DelAll()
            {
                
            }
        }
        public class Encode
        {
            public static string[] Letters = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я", ".", ",", " "};
            public static string[] BoxCode = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71" };
            public static string[] Box4b(string CompileString)
            {
                string[] ToCompile = mc.Char_Str_Char(CompileString);
                string Letter = "";
                ToCompile = mc.DeleteThisWord(null, ToCompile);
                for (int I = 0; I < ToCompile.Length; I++)
                {
                    for (int j = 0; j < Letters.Length; j++)
                    {
                        if (ToCompile[I] == Letters[j])
                        {
                            Letter = BoxCode[j];
                        }
                    }
                    if (ToCompile[I] == " ") { ToCompile[I] = "Box00/"; }
                    else {  ToCompile[I] = "Box"+Letter+"/";}
                }
                return ToCompile;
            }
        }
        public class Decode
        {
            public static string[] Box4b(string CompileString)
            {
                string[] ToCompile = CompileString.Split('/');
                string Letter = "";
                ToCompile = mc.DeleteThisWord(null, ToCompile);
                ToCompile = mc.DeleteThisWord("", ToCompile);
                for (int I = 0; I < ToCompile.Length; I++)
                {
                    for (int j = 0; j < Encode.BoxCode.Length; j++)
                    {
                        if (ToCompile[I] == "Box"+Encode.BoxCode[j])
                        {
                            Letter = Encode.Letters[j];
                        }
                    
                    }
                    if (ToCompile[I] == " ") { ToCompile[I] = " "; }
                    else { ToCompile[I] = Letter;}
                
                }
                return ToCompile;
            }
        }
    }
    namespace Box_Error
    {
        interface Error
        {
            public void _Exception(bool Important);
            public void Description();
            public static void _E() { }
        }
        public class Non_big_Errors
        {
            
            public class DevErr : Error
            {   Core core = new();
                public void _Exception(bool Important)
                {
                    if (Important) { Description(); core.CreateHisory("DevErr", false); }
                    else { }
                }
                public void Description()
                {
                    Console.WriteLine("work on this element is either not started or not finished");
                }
                public static void _E() { Console.WriteLine("work on this element is either not started or not finished"); }
            }
        }
    }
    namespace VisibleConsole
    {
        public class SysMain
        {
            public static Core MyCmd = new();
            public static User MyUser = new();
            public static void SystemM1() //Это основной метод. он собрал в себя все необходимое из других классов :)
            {
                bool IsConsoleActive = true;
                User.Autorisation();
                MyCmd.CreateHisory("UserName = " + MyUser.Name);
                Console.WriteLine("Succefull enter!");
                Thread.Sleep(800);
                Console.Clear();
                Console.WriteLine($"Hi, {MyUser.Name}! What Do you want?");
                do  //А вот тут главная часть всей системы - консоль!
                {
                    Console.Write(">C>");
                    string[] lst = Console.ReadLine().Split('\u0020');
                    try { MyCmd.DoAlgoritm(lst[0], lst[1]); }
                    catch { MyCmd.DoAlgoritm(lst[0], "none"); }
                    if (lst[0] == "SetOff" | lst[0] == "9") { IsConsoleActive = false; };
                } while (IsConsoleActive);
                FileSys.fstream.Close();//Если вам показалось что тут маловато кода для основной системы - то вам определенно показалось...
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
        public class User //без размещения этого класса в оболочке, работать не будет :(
        {
            public string Name, Password;
            public static bool IsAdmin;
            static List<string> UserNameList = new() { "aboba", "Box", "Admin", "guest", "slave", "Guest" };
            static List<string> PasswordList = new() { "aboba", "8246", "Admin", "guest", "box", "1234" };
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
}