using System;
using System.IO;

namespace DeserializeJsonToListT
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "data.json");
            ClienteReport.Run(path, Console.Out);
            Console.ReadKey();
        }
    }
}
