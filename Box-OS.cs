/* 
 * Привет!
 * Надеюсь ты поймешь мой код, я постарался сделать переменные максимально понятными :)
 * Так же я посторался сделать максимально много комментариев :)
 * 
 * Дата начала проекта: 07.11.2022
 */

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



/*
 * Для продолжения просмотра перейдите в Core.cs
 * Надеюсь вам понравилось :)
 */