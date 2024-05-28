using System;

namespace EXESpy
{
    public static class BC
    {
        public static void LogPair(string key, string value)
        {
            LogIn($"{key}: {value}");
        }
        public static void LogIn(string message)
        {
            Log($"    {message}");
        }
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
        public static void NL()
        {
            Console.WriteLine();
        }
    }
}