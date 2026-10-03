using System;
using System.IO;

namespace SerializeAndDeserializeJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonData = "{\"GetBookingResult\": {\"reserva\":{\"fecha_creacion\":{\"#text\":\"15FEB17\"}, \"hora_creacion\":{\"#text\":\"2133\"}, \"responsable\":{\"tipo_reserva\":\"WEBPAS\",\"cod_cia\":\"OB\",\"off_resp\":\"OBW101\"},\"localizador_resiber\":{\"#text\":\"P7S44\"}}}}";
            BookingJsonProcessor.WriteDetails(jsonData, Console.Out);

            Console.ReadKey();

        }
    }
}
