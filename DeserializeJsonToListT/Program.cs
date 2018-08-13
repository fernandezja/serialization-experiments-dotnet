using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DeserializeJsonToListT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deserialize Json To List<T>");

            var path = Path.Combine(Environment.CurrentDirectory,  "data.json");

            var jsonString = File.ReadAllText(@"data.json");
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonString);
            Console.WriteLine($"Clientes cantidad: {clientes.Count}");

            if (File.Exists(path))
            {
                
                var jsonString = File.ReadAllText(@"data.json");
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonString);
                Console.WriteLine($"Clientes cantidad: {clientes.Count}");
            }
            else
            {
                Console.WriteLine($"No existe el archivo {path}");
            }
            

            

            Console.ReadKey();

        }
}
}
