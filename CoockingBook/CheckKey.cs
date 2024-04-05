using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoockingBook
{
    public class CheckKey
    {
        public static Char CheckPressedKey(string message, Char[] properKeys)
        {
            bool isProper = false;
            ConsoleKeyInfo keyPressed;

            Console.WriteLine();

            do
            {
                Console.Write(message);
                keyPressed = Console.ReadKey();
                if (Array.Exists(properKeys, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                {
                    isProper = true;
                }
                Console.WriteLine("");
            } while (!isProper);

            return keyPressed.KeyChar;
        }

    }
}
