using System;

namespace BlazorUtils.Cli.Utils
{
    internal static class ReadKeyUtils
    {
        public static bool YesNo(string message)
        {
            Console.WriteLine(message);

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.N:
                    return false;
                case ConsoleKey.Y:
                    return true;
                default:
                    return YesNo(message);
            }
        }
    }
}
