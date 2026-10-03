using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SerializeAndDeserializeJson.Tests
{
    [TestClass]
    public class BookingJsonProcessorTests
    {
        [TestMethod]
        public void WriteDetails_WritesBookingAndReservationNodes()
        {
            const string json = "{\"GetBookingResult\":{\"reserva\":{\"fecha_creacion\":{\"#text\":\"15FEB17\"},\"hora_creacion\":{\"#text\":\"2133\"},\"responsable\":{\"tipo_reserva\":\"WEBPAS\",\"cod_cia\":\"OB\",\"off_resp\":\"OBW101\"},\"localizador_resiber\":{\"#text\":\"P7S44\"}}}}";

            using (var output = new RecordingTextWriter())
            {
                BookingJsonProcessor.WriteDetails(json, output);

                var text = output.ToString();
                StringAssert.Contains(text, "\"reserva\"");
                StringAssert.Contains(text, "15FEB17");
                StringAssert.Contains(text, "2133");
                StringAssert.Contains(text, "WEBPAS");
                StringAssert.Contains(text, "P7S44");
            }
        }

        [TestMethod]
        public void WriteDetails_WritesNullForOptionalReservationNodes()
        {
            const string json = "{\"GetBookingResult\":{\"reserva\":{}}}";

            using (var output = new RecordingTextWriter())
            {
                BookingJsonProcessor.WriteDetails(json, output);

                Assert.AreEqual(2, output.Lines.Count);
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsForMalformedJson()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<JsonReaderException>(
                    () => BookingJsonProcessor.WriteDetails("{", output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsForNullJson()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<ArgumentNullException>(
                    () => BookingJsonProcessor.WriteDetails(null, output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsWhenRootIsNotAnObject()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<JsonReaderException>(
                    () => BookingJsonProcessor.WriteDetails("[]", output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsWhenBookingIsMissing()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<NullReferenceException>(
                    () => BookingJsonProcessor.WriteDetails("{\"other\":{}}", output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsWhenReservationIsMissing()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<NullReferenceException>(
                    () => BookingJsonProcessor.WriteDetails("{\"GetBookingResult\":{}}", output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsWhenBookingValueIsNull()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<InvalidOperationException>(
                    () => BookingJsonProcessor.WriteDetails("{\"GetBookingResult\":null}", output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsWhenReservationValueIsNull()
        {
            using (var output = new StringWriter())
            {
                Assert.ThrowsException<InvalidOperationException>(
                    () => BookingJsonProcessor.WriteDetails("{\"GetBookingResult\":{\"reserva\":null}}", output));
            }
        }

        [TestMethod]
        public void WriteDetails_ThrowsWhenOutputIsNull()
        {
            Assert.ThrowsException<NullReferenceException>(
                () => BookingJsonProcessor.WriteDetails("{\"GetBookingResult\":{\"reserva\":{}}}", null));
        }

        [TestMethod]
        public void WriteDetails_WritesEmptyNodesWhenReservationHasNoDetails()
        {
            const string json = "{\"GetBookingResult\":{\"reserva\":{\"fecha_creacion\":{},\"hora_creacion\":{},\"responsable\":{},\"localizador_resiber\":{}}}}";

            using (var output = new RecordingTextWriter())
            {
                BookingJsonProcessor.WriteDetails(json, output);

                StringAssert.Contains(output.ToString(), "\"fecha_creacion\"");
            }
        }

        [TestMethod]
        public void WriteDetails_WritesPrimitiveAndArrayReservationDetails()
        {
            const string json = "{\"GetBookingResult\":{\"reserva\":{\"fecha_creacion\":\"15FEB17\",\"hora_creacion\":2133,\"responsable\":[\"WEBPAS\"],\"localizador_resiber\":true}}}";

            using (var output = new RecordingTextWriter())
            {
                BookingJsonProcessor.WriteDetails(json, output);

                var text = output.ToString();
                StringAssert.Contains(text, "15FEB17");
                StringAssert.Contains(text, "2133");
                StringAssert.Contains(text, "WEBPAS");
                StringAssert.Contains(text, "true");
            }
        }

        private sealed class RecordingTextWriter : StringWriter
        {
            public IList<string> Lines { get; } = new List<string>();

            public override void WriteLine(object value)
            {
                base.WriteLine(value);
            }

            public override void WriteLine(string value)
            {
                Lines.Add(value ?? "null");
                base.WriteLine(value);
            }
        }
    }
}
