using System;

namespace SystemTextJsonConsole
{
    class Program
    {
        private const string JSON_DATA = "{\"ApiUrl\":\"http://127.0.0.1:3000\",\"ClientId\":\"client.app.demo\",\"ClientSecret\":\"anitalavalatina\",\"Scope\":\"api1\",\"GoogleAndroidClientId\":\"abcd-efgh-ijkl-123456789\",\"GoogleiOSClientId\":\"abcd-efgh-ijkl-123456789\",\"FacebookClientId\":\"abcd-efgh-ijkl-123456789\",\"BranchOfficesMapUrl\":\"https://www.google.com/maps/d/u/0/embed?mid=abcd-efgh-ijkl-123456789\",\"Web\":\"https://www.starwars.com/\",\"Facebook\":\"https://es-la.facebook.com/starwars/\",\"Instagram\":\"https://www.instagram.com/starwars/?hl=en\",\"Twitter\":\"https://twitter.com/stwarwars?lang=en\",\"Whatsapp\":\"https://api.whatsapp.com/send?phone=+123456789\"}";


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var data = System.Text.Json.JsonSerializer.Deserialize<CurrentConfiguration>(JSON_DATA);

            Console.WriteLine($"ApiUrl =  {data.ApiUrl}");

            Console.ReadKey();
        }
    }
}