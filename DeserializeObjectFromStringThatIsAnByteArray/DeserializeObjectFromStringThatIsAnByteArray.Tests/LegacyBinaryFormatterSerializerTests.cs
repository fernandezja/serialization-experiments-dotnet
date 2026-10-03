using DeserializeObjectFromStringThatIsAnByteArray;

namespace DeserializeObjectFromStringThatIsAnByteArray.Tests;

public class LegacyBinaryFormatterSerializerTests
{
    [Fact]
    public void Serialize_ThrowsWhenBinaryFormatterIsUnavailable()
    {
        Assert.Throws<PlatformNotSupportedException>(
            () => LegacyBinaryFormatterSerializer.Serialize(new object()));
    }

    [Fact]
    public void Serialize_ReturnsNullForNullInput()
    {
        Assert.Null(LegacyBinaryFormatterSerializer.Serialize(null));
    }

    [Fact]
    public void Deserialize_ThrowsForNullByteArray()
    {
        Assert.Throws<ArgumentNullException>(
            () => LegacyBinaryFormatterSerializer.Deserialize<object>(null!));
    }

    [Fact]
    public void Deserialize_ThrowsWhenBinaryFormatterIsUnavailable()
    {
        Assert.Throws<PlatformNotSupportedException>(
            () => LegacyBinaryFormatterSerializer.Deserialize<object>(Array.Empty<byte>()));
    }
}
