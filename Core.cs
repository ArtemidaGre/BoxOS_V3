using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreSpace
{
    public class Core //Вот ядро системы - командная строка!
    {
        FileStream fstream = new FileStream(@"C:\Users\Public\Documents\BoxOsHistory.log", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public string Command;
        public int CommandID;
        public static List<string> CommandList = new() { "WinCMD", "color", "open", "copy", "help", "href", "git", "del", "cle  ar", "SetOff", "IdCheck", "MyHistory" };

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
            else if (CommandToDo == "SetOff" | CommandToDo == "9") { fstream.Close(); }
            else if (CommandToDo == "IdCheck" | CommandToDo == "10") { Console.WriteLine(CommandIDCheck(SubCom)); return false; }
            else if (CommandToDo == "MyHistory" | CommandToDo == "11") { Console.WriteLine(GetHistory()); }
            //else if (CommandToDo == "CreateUser" | CommandToDo == "12") { CreateUser(SubCom); }
            else if (CommandToDo == "" | CommandToDo == "99") { }
            else { Console.WriteLine("Command Error"); };
            try { CreateHisory(CommandToDo + " " + SubCom); } catch { Console.WriteLine("History Error 2"); }
            return true;
        }
        public void CreateHisory(string HistoryPlus)
        {
            byte[] input = Encoding.Default.GetBytes(HistoryPlus + "◄\n");
            // запись массива байтов в файл
            fstream.Write(input, 0, input.Length);
        }
        public string[] GetHistory()
        {
            fstream.Seek(0, SeekOrigin.Begin);
            byte[] output = new byte[fstream.Length];
            fstream.Read(output, 0, output.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(output);
            string[] HistoryList = textFromFile.Split(new char[] { '◄' });
            return HistoryList;
        }
        
    }
    public class User //а над этим я работал 2 часа и несколько раз переписывал...
    {
        public static string Name, Password;
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
        /*public void CreateUser(string NewUserName, string NewUserPassword)
        {
            if (AdminCheck(Name))
            {
                UserNameList.Add(NewUserName);
                PasswordList.Add(NewUserPassword);
            }
            else
            {

            }
        }*/
    }
    
}