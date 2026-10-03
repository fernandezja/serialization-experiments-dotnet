namespace SerializeObjectToByteArray.Tests
{
    public class SerializationTests
    {
        [Fact]
        public void ObjectToByteArray_Null_ReturnsNull()
        {
            Assert.Null(Program.ObjectToByteArray(null));
        }

        [Fact]
        public void ObjectToByteArray_NonNull_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(
                () => Program.ObjectToByteArray(new Jedi { Id = 11, Name = "Yoda" }));
        }

        [Fact]
        public void ByteArrayToObject_Null_ThrowsArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => Program.ByteArrayToObject<Jedi>(null!));

            Assert.Equal("data", exception.ParamName);
        }

        [Fact]
        public void ByteArrayToObject_NonNull_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(
                () => Program.ByteArrayToObject<Jedi>([1, 2, 3]));
        }

        [Fact]
        public void Main_ThrowsPlatformNotSupportedExceptionOnNet10()
        {
            Assert.Throws<PlatformNotSupportedException>(
                () => Program.Main([]));
        }

        [Fact]
        public void Jedi_PropertiesCanBeReadAndWritten()
        {
            var jedi = new Jedi { Id = 11, Name = "Yoda" };

            Assert.Equal(11, jedi.Id);
            Assert.Equal("Yoda", jedi.Name);
        }
    }
}
