using System;
using System.Collections.Generic;
using System.Text;

namespace FileTypeConverter
{
    public static class Utility
    {
        public static void PrintColorMessage(ConsoleColor color, string message)
        {

            Console.ForegroundColor = color;

            //tell user its not a number
            Console.WriteLine(message);

            //reset text color
            Console.ResetColor();
        }
    }
}
