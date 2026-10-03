using DeserializeJsonToListT;
using System.Globalization;

namespace DeserializeJsonToListT.Tests;

public class ClienteReportTests
{
    [Fact]
    public void Run_ReportsMissingFile()
    {
        var path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.json");
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        ClienteReport.Run(path, output);

        Assert.Contains("Deserialize Json To List<T>", output.ToString());
        Assert.Contains($"No existe el archivo {path}", output.ToString());
        Assert.DoesNotContain("Clientes cantidad:", output.ToString());
    }

    [Fact]
    public void Run_ReportsCustomersAndTheirDates()
    {
        const string json = """
            [
              {"Nombre":"Ana","FechaCreacion":"/Date(0)/","FechaModificacion":"/Date(1000)/","FechaModificacionUtc":"/Date(2000)/"},
              {"Nombre":"Luis","FechaCreacion":"/Date(3000)/","FechaModificacion":"/Date(4000)/","FechaModificacionUtc":"/Date(5000)/"}
            ]
            """;
        var path = WriteTemporaryFile(json);
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        try
        {
            ClienteReport.Run(path, output);

            var report = output.ToString();
            Assert.Contains("Clientes cantidad: 2", report);
            var clientes = ClienteJsonDeserializer.Deserialize(json)!;
            foreach (var cliente in clientes)
            {
                Assert.Contains($"Nombre: {cliente.Nombre}", report);
                Assert.Contains($"FechaCreacion: {cliente.FechaCreacion}", report);
                Assert.Contains($"FechaModificacion: {cliente.FechaModificacion}", report);
                Assert.Contains($"FechaModificacionUtc: {cliente.FechaModificacionUtc}", report);
            }

            Assert.Equal(2, CountOccurrences(report, " --------------------------------------------"));
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void Run_ReportsZeroCustomersForEmptyArray()
    {
        var path = WriteTemporaryFile("[]");
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        try
        {
            ClienteReport.Run(path, output);

            Assert.Contains("Clientes cantidad: 0", output.ToString());
            Assert.DoesNotContain("Nombre:", output.ToString());
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void Run_ReportsZeroCustomersForJsonNull()
    {
        var path = WriteTemporaryFile("null");
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        try
        {
            ClienteReport.Run(path, output);

            Assert.Contains("Clientes cantidad: 0", output.ToString());
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void Run_PropagatesInvalidJsonErrors()
    {
        var path = WriteTemporaryFile("{");
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        try
        {
            Assert.Throws<Newtonsoft.Json.JsonSerializationException>(
                () => ClienteReport.Run(path, output));
        }
        finally
        {
            File.Delete(path);
        }
    }

    private static string WriteTemporaryFile(string contents)
    {
        var path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.json");
        File.WriteAllText(path, contents);
        return path;
    }

    private static int CountOccurrences(string value, string substring)
    {
        var count = 0;
        var index = 0;

        while ((index = value.IndexOf(substring, index, StringComparison.Ordinal)) >= 0)
        {
            count++;
            index += substring.Length;
        }

        return count;
    }
}
