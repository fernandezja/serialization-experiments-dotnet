using System;

namespace SystemTextJsonConsole
{
    class Program
    {
        private const string JSON_DATA = "{\"ApiUrl\":\"http://192.168.2.146:61888\",\"ClientId\":\"app.mobile.v202104.cc\",\"ClientSecret\":\"anitalavalatina\",\"Scope\":\"api1\",\"GoogleAndroidClientId\":\"898285051695-e1mb76cqu2a1uu2n2biee5rfedjhn8l1.apps.googleusercontent.com\",\"GoogleiOSClientId\":\"898285051695-s1b3c94mdcn9uu9ermn9g5tnvddmqh9h.apps.googleusercontent.com\",\"FacebookClientId\":\"237249769725125\",\"BranchOfficesMapUrl\":\"https://www.google.com/maps/d/u/0/embed?mid=1vcWi4VRv4Fl5kVJRjrW686An30k\",\"Web\":\"https://www.aguasdecorrientes.com/\",\"Facebook\":\"https://es-la.facebook.com/OficialAguas/\",\"Instagram\":\"https://www.instagram.com/oficialaguas/?hl=en\",\"Twitter\":\"https://twitter.com/oficialaguas?lang=en\",\"Whatsapp\":\"https://api.whatsapp.com/send?phone=+54379507777\"}";


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var data = System.Text.Json.JsonSerializer.Deserialize<CurrentConfiguration>(JSON_DATA);

            Console.WriteLine($"ApiUrl =  {data.ApiUrl}");

            Console.ReadKey();
        }
    }
}
