using DeserializeObjectFromStringThatIsAnByteArray;
using PluginDesign.ScreenElements.SequentialElement;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace DeserializeObjectFromStringThatIsAnByteArray.Tests;

public class LegacyBinaryFormatterDemoTests
{
    [Fact]
    public void Run_WritesKeysAndAllElementProperties()
    {
        var data = new Hashtable
        {
            ["screen-a"] = new List<SequentialElementGC>
            {
                new() { Id = "view-1", IdElement = "element-1", EstimuloCritico = true },
                new() { Id = "view-2", IdElement = "element-2", EstimuloCritico = false }
            },
            ["screen-empty"] = new List<SequentialElementGC>()
        };
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        LegacyBinaryFormatterDemo.Run("0001", output, bytes =>
        {
            Assert.Equal(new byte[] { 0x00, 0x01 }, bytes);
            return data;
        });

        var result = output.ToString();
        Assert.Contains("Keys", result);
        Assert.Contains("Content", result);
        Assert.Contains("screen-a", result);
        Assert.Contains("screen-empty", result);
        Assert.Contains("Item 0", result);
        Assert.Contains("Item 1", result);
        Assert.Contains("Id > view-1", result);
        Assert.Contains("Id > view-2", result);
        Assert.Contains("EstimuloCritico > True", result);
        Assert.Contains("EstimuloCritico > False", result);
        Assert.Contains("IdElement > element-1", result);
        Assert.Contains("IdElement > element-2", result);
    }

    [Fact]
    public void Run_HandlesEmptyHashtable()
    {
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        LegacyBinaryFormatterDemo.Run("00", output, _ => new Hashtable());

        Assert.Contains("Keys", output.ToString());
        Assert.Contains("Content", output.ToString());
        Assert.DoesNotContain(" - Key >", output.ToString());
        Assert.DoesNotContain(" - Item ", output.ToString());
    }

    [Fact]
    public void Run_PropagatesInvalidHexInput()
    {
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        Assert.Throws<FormatException>(() => LegacyBinaryFormatterDemo.Run("xyz", output));
    }

    [Fact]
    public void Run_PropagatesDeserializationErrors()
    {
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        Assert.Throws<InvalidDataException>(
            () => LegacyBinaryFormatterDemo.Run("00", output, _ =>
                throw new InvalidDataException()));
    }

    [Fact]
    public void Run_ThrowsWhenBinaryFormatterIsUnavailable()
    {
        using var output = new StringWriter(CultureInfo.InvariantCulture);

        Assert.Throws<PlatformNotSupportedException>(
            () => LegacyBinaryFormatterDemo.Run("00", output));
    }
}
