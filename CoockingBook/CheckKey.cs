using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoockingBook
{
    public class CheckKey
    {
        public static Char CheckPressedKey(string msg, Char[] properKeys)
        {
            bool proper = true;
            ConsoleKeyInfo keyPressed;

            Console.WriteLine();

            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                if (Array.Exists(properKeys, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                {
                    proper = false;
                }
                Console.WriteLine("");
            } while (proper);

            return keyPressed.KeyChar;
        }

    }
}
