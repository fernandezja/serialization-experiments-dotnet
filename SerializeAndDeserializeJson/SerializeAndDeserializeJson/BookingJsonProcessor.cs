using Newtonsoft.Json.Linq;
using System.IO;

namespace SerializeAndDeserializeJson
{
    public static class BookingJsonProcessor
    {
        public static void WriteDetails(string json, TextWriter output)
        {
            var booking = JObject.Parse(json)["GetBookingResult"];
            var reservation = booking["reserva"];

            output.WriteLine(booking);
            output.WriteLine(reservation);
            output.WriteLine(reservation["fecha_creacion"]);
            output.WriteLine(reservation["hora_creacion"]);
            output.WriteLine(reservation["responsable"]);
            output.WriteLine(reservation["localizador_resiber"]);
        }
    }
}
