using DeserializeObjectFromStringThatIsAnByteArray;

namespace DeserializeObjectFromStringThatIsAnByteArray.Tests;

public class HexByteArrayConverterTests
{
    [Fact]
    public void FromHexString_ConvertsBytes()
    {
        Assert.Equal(new byte[] { 0x00, 0x7F, 0xA5, 0xFF },
            HexByteArrayConverter.FromHexString("007fa5FF"));
    }

    [Fact]
    public void FromHexString_ReturnsEmptyArrayForEmptyString()
    {
        Assert.Empty(HexByteArrayConverter.FromHexString(string.Empty));
    }

    [Theory]
    [InlineData("0")]
    [InlineData("GG")]
    [InlineData("12 34")]
    public void FromHexString_ThrowsForInvalidInput(string value)
    {
        Assert.Throws<FormatException>(() => HexByteArrayConverter.FromHexString(value));
    }

    [Fact]
    public void FromHexString_ThrowsForNullInput()
    {
        Assert.Throws<ArgumentNullException>(
            () => HexByteArrayConverter.FromHexString(null!));
    }
}
