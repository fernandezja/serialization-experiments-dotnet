using DeserializeJsonToListT;
using Newtonsoft.Json;

namespace DeserializeJsonToListT.Tests;

public class ClienteJsonDeserializerTests
{
    [Fact]
    public void Deserialize_MapsAllClienteProperties()
    {
        const string json = """
            [{
              "Numero": 14,
              "Id": "a22f9dde-468a-4699-9dea-106d32368f88",
              "Nombre": "Jose",
              "Edad": 34,
              "Telefono": "555-1234",
              "Mail": "jose@example.com",
              "Saldo": 1234.5678,
              "FechaCreacion": "/Date(0)/",
              "FechaCreacionUtc": "/Date(1000)/",
              "FechaModificacion": "/Date(2000)/",
              "FechaModificacionUtc": "/Date(3000)/",
              "Proceso": 2,
              "Usuario": "admin",
              "Estado": "ACTIVO"
            }]
            """;

        var result = Assert.Single(ClienteJsonDeserializer.Deserialize(json)!);

        Assert.Equal(14, result.Numero);
        Assert.Equal("a22f9dde-468a-4699-9dea-106d32368f88", result.Id);
        Assert.Equal("Jose", result.Nombre);
        Assert.Equal(34, result.Edad);
        Assert.Equal("555-1234", result.Telefono);
        Assert.Equal("jose@example.com", result.Mail);
        Assert.Equal(1234.5678m, result.Saldo);
        Assert.Equal(0, new DateTimeOffset(result.FechaCreacion).ToUnixTimeMilliseconds());
        Assert.Equal(TimeSpan.FromSeconds(1), result.FechaCreacionUtc - result.FechaCreacion);
        Assert.Equal(TimeSpan.FromSeconds(2), result.FechaModificacion - result.FechaCreacion);
        Assert.Equal(TimeSpan.FromSeconds(3), result.FechaModificacionUtc - result.FechaCreacion);
        Assert.Equal(2, result.Proceso);
        Assert.Equal("admin", result.Usuario);
        Assert.Equal("ACTIVO", result.Estado);
    }

    [Fact]
    public void Deserialize_ReturnsEmptyListForEmptyJsonArray()
    {
        var result = ClienteJsonDeserializer.Deserialize("[]");

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Deserialize_ReturnsNullForJsonNull()
    {
        Assert.Null(ClienteJsonDeserializer.Deserialize("null"));
    }

    [Theory]
    [InlineData("{")]
    [InlineData("[")]
    public void Deserialize_ThrowsForMalformedJson(string json)
    {
        Assert.Throws<JsonSerializationException>(() => ClienteJsonDeserializer.Deserialize(json));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Deserialize_ReturnsNullForEmptyJson(string json)
    {
        Assert.Null(ClienteJsonDeserializer.Deserialize(json));
    }

    [Fact]
    public void Deserialize_ThrowsWhenRootIsNotAnArray()
    {
        Assert.Throws<JsonSerializationException>(
            () => ClienteJsonDeserializer.Deserialize("{\"Numero\":1}"));
    }

    [Fact]
    public void Deserialize_IgnoresUnknownProperties()
    {
        var result = Assert.Single(
            ClienteJsonDeserializer.Deserialize("[{\"Nombre\":\"Ana\",\"PropiedadExtra\":true}]")!);

        Assert.Equal("Ana", result.Nombre);
    }
}
