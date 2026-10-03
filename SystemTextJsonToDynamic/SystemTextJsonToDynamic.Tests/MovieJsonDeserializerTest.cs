using System.Text.Json;
using SystemTextJsonToDynamic;

namespace SystemTextJsonToDynamic.Tests;

public class MovieJsonDeserializerTest
{
    [Fact]
    public void Deserialize_ReadsMovieProperties()
    {
        var movie = MovieJsonDeserializer.Deserialize("{\"Title\":\"Star Wars\",\"Year\":1977}");
        Assert.NotNull(movie);
        Assert.Equal("Star Wars", movie!.Title);
        Assert.Equal(1977, movie.Year);
    }

    [Fact]
    public void Deserialize_IsCaseInsensitive()
    {
        var movie = MovieJsonDeserializer.Deserialize("{\"title\":\"Alien\",\"year\":1979}");
        Assert.NotNull(movie);
        Assert.Equal("Alien", movie!.Title);
        Assert.Equal(1979, movie.Year);
    }

    [Fact]
    public void Deserialize_ReturnsNullForJsonNull() => Assert.Null(MovieJsonDeserializer.Deserialize("null"));

    [Fact]
    public void Deserialize_UsesDefaultsForMissingProperties()
    {
        var movie = MovieJsonDeserializer.Deserialize("{}");
        Assert.NotNull(movie);
        Assert.Equal("", movie!.Title);
        Assert.Equal(0, movie.Year);
    }

    [Fact]
    public void Deserialize_ThrowsForMalformedJson() => Assert.Throws<JsonException>(() => MovieJsonDeserializer.Deserialize("{"));

    [Fact]
    public void Deserialize_ThrowsForIncompatiblePropertyType() => Assert.Throws<JsonException>(() => MovieJsonDeserializer.Deserialize("{\"Year\":\"not a number\"}"));
}
