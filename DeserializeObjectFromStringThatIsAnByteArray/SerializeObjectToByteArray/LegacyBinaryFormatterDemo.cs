using PluginDesign.ScreenElements.SequentialElement;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

namespace DeserializeObjectFromStringThatIsAnByteArray
{
    internal static class LegacyBinaryFormatterDemo
    {
        internal static void Run(string hexString, TextWriter output)
        {
            Run(hexString, output, LegacyBinaryFormatterSerializer.Deserialize<Hashtable>);
        }

        internal static void Run(
            string hexString,
            TextWriter output,
            Func<byte[], Hashtable> deserialize)
        {
            var buffer = HexByteArrayConverter.FromHexString(hexString);
            var bufferAsString = Encoding.Default.GetString(buffer);

            output.WriteLine(bufferAsString);

            var table = deserialize(buffer);

            output.WriteLine("----------------------------------------------------------------");
            output.WriteLine("Keys");
            foreach (var key in table.Keys)
            {
                output.WriteLine($" - Key > {key}");
            }

            output.WriteLine("----------------------------------------------------------------");
            output.WriteLine("Content");
            foreach (var key in table.Keys)
            {
                output.WriteLine($" - Key > {key}");
                output.WriteLine(" - Content");
                var elements = (List<SequentialElementGC>)table[key];
                var index = 0;

                foreach (var element in elements)
                {
                    output.WriteLine($" - Item {index}");
                    output.WriteLine($"        - Id > {element.Id}");
                    output.WriteLine($"        - EstimuloCritico > {element.EstimuloCritico}");
                    output.WriteLine($"        - IdElement > {element.IdElement}");
                    index++;
                }

                output.WriteLine();
            }
        }
    }
}
