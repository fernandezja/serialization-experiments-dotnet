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

            var serializerSettings = new JsonSerializerSettings(){
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            if (File.Exists(path))
            {
                
                var jsonString = File.ReadAllText(@"data.json");
                var clientes = JsonConvert
                                .DeserializeObject<List<Cliente>>(jsonString, 
                                                                  serializerSettings);
                Console.WriteLine($"Clientes cantidad: {clientes.Count}");

                foreach (var item in clientes)
                {
                    Console.WriteLine($"    |_ Nombre: {item.Nombre}");
                    Console.WriteLine($"    |_ FechaCreacion: {item.FechaCreacion}");
                    Console.WriteLine($"    |_ FechaModificacion: {item.FechaModificacion}");
                    Console.WriteLine($"    |_ FechaModificacionUtc: {item.FechaModificacionUtc}");

                    Console.WriteLine($" --------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No existe el archivo {path}");
            }
            

            

            Console.ReadKey();

        }
}
}
