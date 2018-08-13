using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAndDeserializeJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonDataConError = "\"GetBookingResult\": \"{\"reserva\":{\"fecha_creacion\":{\"#text\":\"15FEB17\"},\"hora_creacion\":{\"#text\":\"2133\"},\"responsable\":{\"tipo_reserva\":\"WEBPAS\",\"cod_cia\":\"OB\",\"off_resp\":\"OBW101\"},\"localizador_resiber\":{\"#text\":\"P7S44\"}";


            var jsonData2 = "{\"reserva\":{\"fecha_creacion\":{\"#text\":\"15FEB17\"},\"hora_creacion\":{\"#text\":\"2133\"},\"responsable\":{\"tipo_reserva\":\"WEBPAS\",\"cod_cia\":\"OB\",\"off_resp\":\"OBW101\"},\"localizador_resiber\":{\"#text\":\"P7S44\"}}}";

            var jsonData =         "{\"GetBookingResult\": {\"reserva\":{\"fecha_creacion\":{\"#text\":\"15FEB17\"}, \"hora_creacion\":{\"#text\":\"2133\"}, \"responsable\":{\"tipo_reserva\":\"WEBPAS\",\"cod_cia\":\"OB\",\"off_resp\":\"OBW101\"},\"localizador_resiber\":{\"#text\":\"P7S44\"}}}}";

            dynamic demo = Newtonsoft.Json.Linq.JObject.Parse(jsonData);

            Console.WriteLine(demo.GetBookingResult);
            Console.WriteLine(demo.GetBookingResult.reserva);
            Console.WriteLine(demo.GetBookingResult.reserva.fecha_creacion);
            Console.WriteLine(demo.GetBookingResult.reserva.hora_creacion);
            Console.WriteLine(demo.GetBookingResult.reserva.responsable);
            Console.WriteLine(demo.GetBookingResult.reserva.localizador_resiber);
            
            Console.ReadKey();

        }
    }
}
