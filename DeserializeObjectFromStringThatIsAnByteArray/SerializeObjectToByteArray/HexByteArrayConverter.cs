using System;

namespace DeserializeObjectFromStringThatIsAnByteArray
{
    internal static class HexByteArrayConverter
    {
        internal static byte[] FromHexString(string value)
        {
            return Convert.FromHexString(value);
        }
    }
}
