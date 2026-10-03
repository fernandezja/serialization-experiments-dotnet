using System.IO;

namespace DeserializeJsonToListT
{
    public static class ClienteReport
    {
        public static void Run(string path, TextWriter output)
        {
            output.WriteLine("Deserialize Json To List<T>");

            if (!File.Exists(path))
            {
                output.WriteLine($"No existe el archivo {path}");
                return;
            }

            var clientes = ClienteJsonDeserializer.Deserialize(File.ReadAllText(path));
            output.WriteLine($"Clientes cantidad: {clientes?.Count ?? 0}");

            if (clientes == null)
            {
                return;
            }

            foreach (var item in clientes)
            {
                output.WriteLine($"    |_ Nombre: {item.Nombre}");
                output.WriteLine($"    |_ FechaCreacion: {item.FechaCreacion}");
                output.WriteLine($"    |_ FechaModificacion: {item.FechaModificacion}");
                output.WriteLine($"    |_ FechaModificacionUtc: {item.FechaModificacionUtc}");
                output.WriteLine(" --------------------------------------------");
            }
        }
    }
}
