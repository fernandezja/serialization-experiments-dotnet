using System;
using System.Dynamic;
using System.Text.Json;

namespace SystemTextJsonToDynamic
{
    public sealed class Movie
    {
        public string Title { get; set; } = "";
        public int Year { get; set; }
    }

    public static class MovieJsonDeserializer
    {
        public static Movie? Deserialize(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true
            };

            return JsonSerializer.Deserialize<Movie>(json, options);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var jsonData = "{\"Title\":\"Star Wars: Episode IV - A New Hope\", \"Year\":1977}";

            var object1 = MovieJsonDeserializer.Deserialize(jsonData);

            Console.Write($"Data Json: {object1}");

            Console.ReadKey();
        }
    }
}
