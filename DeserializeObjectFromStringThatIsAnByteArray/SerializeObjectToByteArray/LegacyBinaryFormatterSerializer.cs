#nullable enable
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeserializeObjectFromStringThatIsAnByteArray
{
    internal static class LegacyBinaryFormatterSerializer
    {
        internal static byte[]? Serialize(object? value)
        {
            if (value == null)
            {
                return null;
            }

#pragma warning disable SYSLIB0011
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, value);
                return stream.ToArray();
            }
        }

        internal static T Deserialize<T>(byte[] data)
        {
            ArgumentNullException.ThrowIfNull(data);

            using (var stream = new MemoryStream(data))
            {
#pragma warning disable SYSLIB0011
                var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
