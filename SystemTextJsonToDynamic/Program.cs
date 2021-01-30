using System;
using System.Dynamic;
using System.Text.Json;

namespace SystemTextJsonToDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonData = "{\"Title\":\"Star Wars: Episode IV - A New Hope\", \"Year\":1977}";

            //with anonymous type 
            var movie = new
            {
                Title = "",
                Year= 0
            };


            var options = new JsonSerializerOptions { 
                PropertyNameCaseInsensitive = true, 
                IncludeFields = true };

            var object1 = JsonSerializer.Deserialize(jsonData, movie.GetType());

            Console.Write($"Data Json: {object1}");

            Console.ReadKey();
        }
    }
}
