using System;

namespace ExeSpy
{
    public static class Print
    {
        public static void Pair(string key, string value)
        {
            Indented($"{key}: {value}");
        }
        public static void Indented(string message)
        {
            Line($"    {message}");
        }
        public static void NewLine()
        {
            Line("");
        }
        public static void Line(string message)
        {
            Console.WriteLine(message);
        }
    }
}