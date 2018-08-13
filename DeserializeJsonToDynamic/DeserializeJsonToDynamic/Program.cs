using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializeJsonToDynamic
{
    class Program
    {
        static void Main(string[] args)
        {

            var jsonData = "{\"Dolares\":[{\"Valor\": \"603,31\",\"Fecha\": \"2018-04-27\"}]}";
            dynamic demo = Newtonsoft.Json.Linq.JObject.Parse(jsonData);

            Console.WriteLine(demo.Dolares[0].Valor);
            Console.WriteLine(demo.Dolares[0].Fecha);

            foreach (var item in demo.Dolares)
            {
                Console.WriteLine(item.Valor);
                Console.WriteLine(item.Fecha);
            }


            DolarViewModel demo2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DolarViewModel>(jsonData);
            Console.WriteLine(demo2.Dolares[0].Valor);
            Console.WriteLine(demo2.Dolares[0].Fecha);

            foreach (var item in demo2.Dolares)
            {
                Console.WriteLine(item.Valor);
                Console.WriteLine(item.Fecha);
            }



            Console.ReadKey();
        }
    }
}
